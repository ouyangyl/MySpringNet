REM Remove the plug in to the Visual Studio.NET 2003 help system
InnovaHxReg /U /P /productnamespace:MS.VSCC.2003 /producthxt:_DEFAULT /namespace:Spring.NET /hxt:_DEFAULT

REM Un-Register the help file (title in Help 2.0 terminology)
InnovaHxReg /U /T /namespace:Spring.NET /id:Spring.NET-1.1.2 /langid:1033 /helpfile:"Spring.NET.hxs"

REM Un-Register the Namespace
InnovaHxReg /U /N /Namespace:Spring.NET /Description:"Spring.Testing.NUnit" /Collection:COL_Spring-1.1.0.hxc
