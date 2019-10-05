#!/usr/bin/env fsharpi

open System
open System.IO
open System.Linq

#r "System.Configuration"
#load "../fsx/InfraLib/Misc.fs"
#load "../fsx/InfraLib/Process.fs"
#load "../fsx/InfraLib/Network.fs"
open FSX.Infrastructure
open Process

let nugetDownloadUri = Uri "https://dist.nuget.org/win-x86-commandline/v4.5.1/nuget.exe"
Network.DownloadFile nugetDownloadUri

// this is a translation of doing this in unix:
// 0.1.0-date`date +%Y%m%d-%H%M`.git-`echo $GITHUB_SHA | cut -c 1-7`
let GetIdealNugetVersion (initialVersion: string) =
    let dateSegment = sprintf "date%s" (DateTime.UtcNow.ToString "yyyyMMdd-hhmm")
    let githubEnvVarNameForGitHash = "GITHUB_SHA"
    let gitHash = Environment.GetEnvironmentVariable githubEnvVarNameForGitHash
    if gitHash = null then
        //TODO: in this case we should just launch a git command
        failwithf "Environment variable %s not found, not running under GitHubActions?"
                  githubEnvVarNameForGitHash
    let gitHashDefaultShortLength = 7
    let gitShortHash = gitHash.Substring(0, gitHashDefaultShortLength)
    let gitSegment = sprintf "git-%s" gitShortHash
    let finalVersion = sprintf "%s.0-%s.%s"
                               initialVersion dateSegment gitSegment
    finalVersion

let packageName = "Xamarin.Forms.Background"
let rootDir = DirectoryInfo(Path.Combine(__SOURCE_DIRECTORY__, ".."))
let nugetExe = Path.Combine(rootDir.FullName, "nuget.exe") |> FileInfo
let nuspecFile = Path.Combine(rootDir.FullName, sprintf "%s.nuspec" packageName)
                 |> FileInfo

let nugetVersion = GetIdealNugetVersion "0.10"
let nugetPackCmd =
    {
        Command = nugetExe.FullName
        Arguments = sprintf "pack %s -Version %s"
                            nuspecFile.FullName nugetVersion
    }

Process.SafeExecute (nugetPackCmd, Echo.All) |> ignore

let packageFile = sprintf "%s.%s.nupkg" packageName nugetVersion
let argsPassedToThisScript = Misc.FsxArguments()
if argsPassedToThisScript.Length <> 1 then
    Console.WriteLine "NUGET_API_KEY not passed to script, skipping upload..."
else
    let nugetApiKey = argsPassedToThisScript.First()
    let githubRef = Environment.GetEnvironmentVariable "GITHUB_REF"
    if githubRef <> "refs/heads/master" then
        Console.WriteLine "Branch different than master, skipping upload..."
    else
        let defaultNugetFeedUrl = "https://api.nuget.org/v3/index.json"
        let nugetPushCmd =
            {
                Command = "dotnet"
                Arguments = sprintf "nuget push %s -k %s -s %s"
                                    packageFile nugetApiKey defaultNugetFeedUrl
            }
        Process.SafeExecute (nugetPushCmd, Echo.All) |> ignore

