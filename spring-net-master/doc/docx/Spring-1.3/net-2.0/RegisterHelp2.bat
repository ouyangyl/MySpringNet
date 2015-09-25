REM In order to run this Help 2 registration script you must have
REM  all COL_* files and the .hxs file in the same directory as 
REM  this file. Additionally, InnoHxReg.exe must be in the same
REM  directory or in the system path.
REM
REM For more information on deploying Help 2 files, refer to the 
REM  HelpStudio on-line help file under the 'Deploying the Help 
REM  System' section.

REM Register the Namespace
InnovaHxReg /R /N /Namespace:Spring.NET /Description:"Spring-1.3.0" /Collection:COL_Spring-1.3.0.hxc

REM Register the help file (title in Help 2.0 terminology)
InnovaHxReg /R /T /namespace:Spring.NET /id:Spring.NET-1.3.0 /langid:1033 /helpfile:"Spring.NET.hxs"

REM Plug in to the Visual Studio.NET 2005 help system
InnovaHxReg /R /P /productnamespace:MS.VSIPCC.v80 /producthxt:_DEFAULT /namespace:Spring.NET /hxt:_DEFAULT
InnovaHxReg /R /F /NameSpace:ms.VSIPCC.v80 /FilterName:"Spring.NET" /FilterQuery:"\"DocSet\" = \"Spring.NET\""

REM Plug in to the Visual Studio.NET 2008 help system
InnovaHxReg /R /P /productnamespace:MS.VSIPCC.v90 /producthxt:_DEFAULT /namespace:Spring.NET /hxt:_DEFAULT

REM This FilterQuery is minimal.
InnovaHxReg /R /F /NameSpace:ms.VSIPCC.v90 /FilterName:"Spring.NET" /FilterQuery:"\"DocSet\" = \"Spring.NET\""

