REM execute this script from the output directory using an elevated prompt

set InstallUtil="C:\Windows\Microsoft.NET\Framework\v2.0.50727\InstallUtil.exe"

%InstallUtil% /i "Test Service.exe"

Net Start "Test Service"
