dotnet build AdvancedLogViewer.msbuild /target:BuildInstaller /p:Runtime=win-x86 /verbosity:normal
dotnet build AdvancedLogViewer.msbuild /target:BuildInstaller /p:Runtime=win-x64 /verbosity:normal

pause