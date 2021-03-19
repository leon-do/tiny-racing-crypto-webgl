@ECHO OFF
set bee=%~dp0..\PackageCache\com.unity.dots.runtime@0.32.0-preview.54\bee~\bee.exe
if [%1] == [] (%bee% -t) else (%bee% %*)
