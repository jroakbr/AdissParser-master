@echo off
rem setup msbuild
set "VSCMD_START_DIR=%CD%"
call "C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\Tools\VsDevCmd.bat"

rem restore nuget packages
nuget restore "..\Installer.sln"

rem build installer solution ... note this does not build .wixproj, just for the other projects
msbuild /p:Configuration=Release /t:clean,build /p:AllowedReferenceRelatedFileExtensions=.pdb "..\Installer.sln"

rem heat temp product components
heat dir "..\Gldd.AdissParser\bin\Release" -cg ProductComponentsFragment -ag -sreg -sfrag -srd -dr INSTALLFOLDER -out "ProductComponentsFragment.temp.wxs" -var var.Gldd.AdissParser.TargetDir

call :CompareHeatFiles "ProductComponentsFragment.wxs" "ProductComponentsFragment.temp.wxs"
if not "%ERRORLEVEL%"=="0" goto end

rem build .msi
msbuild /p:Configuration=Release /p:Platform="x86" /t:clean,build /p:AllowedReferenceRelatedFileExtensions=.pdb "..\Installer.sln"
goto end


:CompareHeatFiles
fc %~1 %~2
if not "%ERRORLEVEL%"=="0" (
	exit /b 1
) else (
	del %~2
	exit /b 0
)

:end
pause