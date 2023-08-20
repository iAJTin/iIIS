@ECHO OFF
CLS

rmdir ..\documentation /s /q

xmldocmd ..\src\lib\iTin.AspNet\iTin.AspNet.Web\iTin.AspNet.Web.IIS\bin\Debug\netstandard2.0\iTin.AspNet.Web.IIS.dll ..\documentation

PAUSE
