REM execute this script from the output directory using an elevated prompt

set InstallUtil="C:\Windows\Microsoft.NET\Framework\v2.0.50727\InstallUtil.exe"

Net Stop "Test Service"

%InstallUtil% /u "Test Service.exe"
