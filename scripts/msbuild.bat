@ECHO OFF

SET ENTERPRISE="%ProgramFiles(x86)%\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin\MSBuild.exe"
SET COMMUNITY="%ProgramFiles(x86)%\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe"
SET BUILDTOOLS="%ProgramFiles(x86)%\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin\MSBuild.exe"

IF EXIST %ENTERPRISE% (
    SET RUNNER=%ENTERPRISE%
) ELSE (
    IF EXIST %COMMUNITY% (
        SET RUNNER=%COMMUNITY%
    ) ELSE (
        IF EXIST %BUILDTOOLS% (
            SET RUNNER=%BUILDTOOLS%
        ) ELSE (
            ECHO msbuild.exe not found, is VS2019 installed?
            EXIT /b 1
        )
    )
)

%RUNNER% %*
