@ECHO OFF
CLS

..\src\.nuget\nuget Pack iIIS.1.0.4.nuspec -NoDefaultExcludes -NoPackageAnalysis -OutputDirectory ..\deployment\nuget

pause

