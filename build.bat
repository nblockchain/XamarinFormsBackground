@ECHO OFF

SET SLN=src\Xamarin.Forms.Background.sln
CALL scripts\msbuild.bat /t:restore %SLN% && CALL scripts\msbuild.bat /t:build /p:Configuration=Release %SLN%
