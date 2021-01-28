# Advanced Log Viewer
Free Log Viewer for easy & powerful log viewing.

## Download
<!--GENERATED LINKS BEGIN-->
You can download the latest release **9.1.1**:
* MSI Installer: [x86](https://github.com/Scarfsail/AdvancedLogViewer/releases/download/9.1.1/AdvancedLogViewer_9.1.1_win-x86.msi) or [x64](https://github.com/Scarfsail/AdvancedLogViewer/releases/download/9.1.1/AdvancedLogViewer_9.1.1_win-x64.msi)
* Portable ZIP: [x86](https://github.com/Scarfsail/AdvancedLogViewer/releases/download/9.1.1/AdvancedLogViewer_9.1.1_win-x86.zip) or [x64](https://github.com/Scarfsail/AdvancedLogViewer/releases/download/9.1.1/AdvancedLogViewer_9.1.1_win-x64.zip)
<!--GENERATED LINKS END-->
**Note: Version 9.x is built in .NET 5 as [self-contained](https://docs.microsoft.com/en-us/dotnet/core/deploying/#publish-self-contained) application. Thus it doesn't need any .NET framework to be installed on the target machine. Because of that, the app is compiled for both x86 and x64 environments with appropriate embedded framework inside. This change increased installer size to ~20 MB but benefit of not requiring installed specific .NET framework won over the increased size of binaries.**

There's also a [changelog](Release/History.md) with all previous versions.

Both versions contain same binaries. MSI version installs ALV into the system, creates shortcut in start menu and user's settings is saved into user's profile. Portable version can be placed anywhere (e.g. network drive, usb drive) and user's settings is saved into the same folder where is the application, nothing is saved in the OS.

*100% CLEAN award granted by [Softpedia](http://www.softpedia.com/progClean/ALV-Advanced-Log-Viewer-Clean-219121.html).

## License
Freeware for personal or commercial use. If you find ALV useful, you can [Donate](http://salplachta.net/AdvancedLogViewer/Donate.aspx) to support my work on this project.

## Platform
Windows 7 and newer, no .NET needs to be installed since version 9.
If you have any specific question, feature request or an issue with the application, please post it in the [issue tracker](https://github.com/Scarfsail/AdvancedLogViewer/issues).

---

**Note:** In case you want a Advanced Log Viewer which runs on .NET 4.0, please download version 7.5.4 and then goto to Application settings and uncheck automatic check for newer versions to avoid notifications about the new ALV which requires newer .NET framework. 
