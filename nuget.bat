@ECHO OFF

CALL scripts\fsi.bat scripts\cloneFsx.fsx %*
CALL scripts\fsi.bat scripts\nuget.fsx %*
