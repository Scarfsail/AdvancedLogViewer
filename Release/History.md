## 9.1.1 - 2021-01-28
###### Download: MSI: [x86](https://github.com/Scarfsail/AdvancedLogViewer/releases/download/9.1.1/AdvancedLogViewer_9.1.1_win-x86.msi)  [x64](https://github.com/Scarfsail/AdvancedLogViewer/releases/download/9.1.1/AdvancedLogViewer_9.1.1_win-x64.msi) or ZIP: [x86](https://github.com/Scarfsail/AdvancedLogViewer/releases/download/9.1.1/AdvancedLogViewer_9.1.1_win-x86.zip) [x64](https://github.com/Scarfsail/AdvancedLogViewer/releases/download/9.1.1/AdvancedLogViewer_9.1.1_win-x64.zip)
#### Fixes
* Application icon disappered since version 9.0.2. Thanks martin-lacina-swi for fixing this bug in #27.
* Clicking on url links inside the app raised unhandled exception since 9.0.2. Thanks 7rakir for fixing this bug in #26.
## 9.1.0 - 2021-01-23
###### Download: MSI: [x86](https://github.com/Scarfsail/AdvancedLogViewer/releases/download/9.1.0/AdvancedLogViewer_9.1.0_win-x86.msi)  [x64](https://github.com/Scarfsail/AdvancedLogViewer/releases/download/9.1.0/AdvancedLogViewer_9.1.0_win-x64.msi) or ZIP: [x86](https://github.com/Scarfsail/AdvancedLogViewer/releases/download/9.1.0/AdvancedLogViewer_9.1.0_win-x86.zip) [x64](https://github.com/Scarfsail/AdvancedLogViewer/releases/download/9.1.0/AdvancedLogViewer_9.1.0_win-x64.zip)
#### Features
* Feature request #24: Added support for tabs beside spaces in custom patterns. It's a new keyword $Tabs$. Also both the existing $Spaces$ and new one $Tabs$ are shown in the help below the edit box.
* Feature request #19: Ability to show / hide context menu "Browse for Logs" in Windows Explorer. Option is in Settings->System Integration
## 9.0.2 - 2021-01-21
###### Download: MSI: [x86](https://github.com/Scarfsail/AdvancedLogViewer/releases/download/9.0.2/AdvancedLogViewer_9.0.2_win-x86.msi)  [x64](https://github.com/Scarfsail/AdvancedLogViewer/releases/download/9.0.2/AdvancedLogViewer_9.0.2_win-x64.msi) or ZIP: [x86](https://github.com/Scarfsail/AdvancedLogViewer/releases/download/9.0.2/AdvancedLogViewer_9.0.2_win-x86.zip) [x64](https://github.com/Scarfsail/AdvancedLogViewer/releases/download/9.0.2/AdvancedLogViewer_9.0.2_win-x64.zip)
#### Big features
* This is the first version built in .NET 5 as self-contained application. Thus it doesn't need any .NET framework to be installed on the target machine. Because of that, the app is compiled for both x86 and x64 environments with appropriate embedded framework inside. This change increased installer size to ~20 MB but benefit of not requiring installed specific .NET framework won over the increased size of binaries. There is visible performance boost mainly on bigger logs thanks to improvements in .NET 5.
#### Fixes
* Fixed various bugs related to enabled UAC causing crashes of ALV.
#### Changes
* All setting and log files are now in Users\{CurrentUser}\AppData\Roaming\AdvancedLogViewer instead of \ProgramData\AdvancedLogViewer. This allows to run ALV even with restricted UAC without need to run app as administrator.
* Serilog is used for ALV internal logging instead of log4net. It brings slightly better performance during logging .
* Settings page is in standard WinForm instead of WPF which brings better performance and less 3rd party WPF libraries only because of that one page.
## 8.1.0 - 2019-01-04
###### Download: [MSI](bin/AdvancedLogViewer_8.1.0.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_8.1.0.zip?raw=true)
#### Features
* Extended log level parser to support various input strings instead of exact Enum's name. Goal is to support Serilog log levels like DBG, WRN, ...
* Log file name parts finder finds also other parts when base name doesn't contain numeric sequence (e.g. it's just FileName.log) and other parts have the sequence before .log (e.g. FileName_1.log)
## 8.0.2 - 2018-08-30
###### Download: [MSI](bin/AdvancedLogViewer_8.0.2.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_8.0.2.zip?raw=true)
#### Big features
* The Advanced Log Viewer has been open sourced! See https://github.com/Scarfsail/AdvancedLogViewer
#### Features
* Add support for wrapping and change font of the message in preview.
* Redesign log level icons.
* Redesign settings page, new look & feel.
* Support for other Solarwinds log files (e.g. OrionWeb.log).
* Log files with only assemblies are always shown, message about custom parsers is skipped.
* Support for log parts with non-continuous numbering.
#### Fixes
* Fixed bug with log parser pattern that has a character "|".
* Support of UTF8 documents.
## 7.6.0 - 2016-01-11
###### Download: [MSI](bin/AdvancedLogViewer_7.6.0.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_7.6.0.zip?raw=true)
#### Features
* Updated to .NET 4.6.1 and improved performance of log loading mainly on x64 OS.
#### Fixes
* Fixed log's code page detection to show characters in UTF8 correctly.
* Fixed few UI glitches.
## 7.5.4 - 2013-05-24
###### Download: [MSI](bin/AdvancedLogViewer_7.5.4.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_7.5.4.zip?raw=true)
#### Features
* New option in settings: "Show type's icon on each row (The icon on left side of each row)". By default the option is enabled, user can disable it and thus hide icons on the log view.
## 7.5.3 - 2013-05-05
###### Download: [MSI](bin/AdvancedLogViewer_7.5.3.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_7.5.3.zip?raw=true)
#### Features
* Parser Patterns: Added possibility to specify mutliple date time formats in case log contains date time in different formats.
#### Fixes
* Significantly improved performance of date time parsing which leads to improved performance of log loading.
## 7.5.2 - 2013-05-04
###### Download: [MSI](bin/AdvancedLogViewer_7.5.2.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_7.5.2.zip?raw=true)
#### Fixes
* Message detail wasn't refreshed when different log was opened and first row was selected.
* LogAdjuster: When active log level doesn't exist, exception (Index must be greater than...) was shown.
* Parser: Fixed issue with parsing line which begins by something else than actual field. (e.g. Something{Date} ...)
## 7.5.1 - 2013-03-31
###### Download: [MSI](bin/AdvancedLogViewer_7.5.1.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_7.5.1.zip?raw=true)
#### Big features
* New search dialog which highlights all rows with found text and shows appropriate marks on the right side to see where are the rows with found text.
#### Features
* Search dialog is by default docked in right upper corner with ability to undock and behave as a standard window.
#### Fixes
* Improved performance of drawing log lines on main screen, less CPU usage during excessive scrolling.
* Due to completely new Find Dialog implementation, fixed bugs reported on the old search dialog (hopefully not introduced so much new bugs;-) ).
## 7.0.2 - 2013-01-07
###### Download: [MSI](bin/AdvancedLogViewer_7.0.2.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_7.0.2.zip?raw=true)
#### Fixes
* When correct parser wasn't detected for the log file, whole log file was shown as one line in the ALV instead of showing message about unknown log format with link to parser patterns manager.
## 7.0.1 - 2013-01-01
###### Download: [MSI](bin/AdvancedLogViewer_7.0.1.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_7.0.1.zip?raw=true)
#### Big features
* Ability to filter log by condition with SQL syntax, example: ((Thread = '9' AND Class LIKE 'MyClass') OR Message LIKE 'Something') 
* New issue tracker for the ALV instead of reporting issues / feature requests in the forum. Visit <a href="http://git.salplachta.net/advanced-log-viewer/issues"><b>git.salplachta.net/advanced-log-viewer/issues</b></a> to see how the issue tracker looks like.
#### Features
* Project switched from .NET 3.5 to .NET 4.0. Advanced Log Viewer requires .NET 4.0 to be installed on the machine. 
* Added new shortcut key to show Parser Manager - CTRL+P
* Few minor performance improvements by using new .NET 4.0 features. More improvements/using of cool .NET4.0 features is planned for next release(s).
#### Fixes
* Fixed issue with progressive loading - log was always loaded without progressive loading -> log was shown at once which caused long loading times for big logs.
* Fixed few minor issues and typos during code refactoring
## 6.5.2 - 2012-12-12
###### Download: [MSI](bin/AdvancedLogViewer_6.5.2.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_6.5.2.zip?raw=true)
#### Big features
* Ability to filter also by regular expression (RegEx) in the text filters (Thread, Type, Class, Message).
#### Features
* Improved performance of filters.
* Jump to nearest item with same Type (Error, Warning, ...) as on currently selected row by CTRL+Up or CTRL+Down.
#### Fixes
* Fixed issue in "Browse for logs" dialog. Logs in root directory were shown in some subfolder.
## 6.2.2 - 2012-11-03
###### Download: [MSI](bin/AdvancedLogViewer_6.2.2.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_6.2.2.zip?raw=true)
#### Fixes
* Fixed issue with movement synchronization between different Log viewers. When this function was enabled, the target Log Viewer's window was activated on every row change in the source Log Viewer.
## 6.2.1 - 2012-10-28
###### Download: [MSI](bin/AdvancedLogViewer_6.2.1.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_6.2.1.zip?raw=true)
#### Features
* Show list of command line parameters from command line (by /? param) or from 'More->Show command line parameters' menu.
* Added new command line parameter: ForceParser to force specific parser for the given log file. See list of command line parameters for more details.
* Associate .LOG files with the ALV application. The switch is on the Settings page in system integration section.
#### Fixes
* Fixed issue with non-parseable date time.
* When log contains first line in different format than the parser specifies, the line is shown only in message column. In previous version the line wasn't shown in the ALV at all.
#### Changes
* When ALV can't parse date time based on provided date time format it's shown only in status bar, no more annoying popup message box.
## 6.1.2 - 2012-10-23
###### Download: [MSI](bin/AdvancedLogViewer_6.1.2.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_6.1.2.zip?raw=true)
#### Fixes
* Open dialog: Filter for all files (*.*) didn't show all files.
* Log view: Ampersand (&) was interpreted as a prefix to underline following character and the ampersand wasn't shown.
## 6.1.1 - 2012-10-14
###### Download: [MSI](bin/AdvancedLogViewer_6.1.1.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_6.1.1.zip?raw=true)
#### Features
* Ability to save currently shown (filtered) log items into new log file which could be shown and filtered again.
## 6.0.2 - 2012-09-30
###### Download: [MSI](bin/AdvancedLogViewer_6.0.2.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_6.0.2.zip?raw=true)
#### Big features
* User can switch between running instances of ALV by pressing CTRL+Tab or from new menu (near to open file button). From this new menu is also possible to run new instance of ALV.
#### Changes
* Toolbar: Buttons order has been changed a bit, text buttons replaced by new icon buttons, some icons revamped.
## 5.6.3 - 2012-09-25
###### Download: [MSI](bin/AdvancedLogViewer_5.6.3.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_5.6.3.zip?raw=true)
#### Fixes
* Date time filter: DateFrom and DateTo was stored in computer's locale format, thus when ALV (mainly portable) was opened on computer with different locale, ALV crashed.
* Quick filters: When user clicks on header and quick filter window is shown the text edit wasn't focused, user had to click into the text edit box manually.
## 5.6.2 - 2012-09-17
###### Download: [MSI](bin/AdvancedLogViewer_5.6.2.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_5.6.2.zip?raw=true)
#### Features
* Added possibility to define also text color for color highlights. So now is possible to define both background and text colors.
#### Changes
* Distinct values in the filter selection (like class names) weren't sorted. They sorted alphabetically now. 
## 5.5.1 - 2012-09-09
###### Download: [MSI](bin/AdvancedLogViewer_5.5.1.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_5.5.1.zip?raw=true)
#### Features
* Added possibility to define filters by checking/unchecking distinct values in the list for Thread, Type and Class columns.
#### Fixes
* Fixed rare exception during log refresh. It occured more often on slow environments (typically VM).
* When ALV is updated, the changelog is shown just in first opened instance of ALV even when the first instance isn't closed.
## 5.4.4 - 2012-08-19
###### Download: [MSI](bin/AdvancedLogViewer_5.4.4.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_5.4.4.zip?raw=true)
#### Features
* Added an icon for TRACE log event type.
#### Fixes
* Fixed issue with scrollbars in message detail pane during refresh. The message detail isn't refreshed when it's not necessary (same item is still selected) -> scroll bars position in the message detail window remains unchanged.
## 5.4.3 - 2012-08-14
###### Download: [MSI](bin/AdvancedLogViewer_5.4.3.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_5.4.3.zip?raw=true)
#### Fixes
* Fixed issue with automatic update when local system date format is set to something non-standard like "yyyyMMdd".
## 5.4.2 - 2012-08-12
###### Download: [MSI](bin/AdvancedLogViewer_5.4.2.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_5.4.2.zip?raw=true)
#### Changes
* When there is a problem during automatic check for an updates of ALV, no error dialog is shown. Just error message in the status bar which disappears within 3 seconds.
## 5.4.1 - 2012-07-29
###### Download: [MSI](bin/AdvancedLogViewer_5.4.1.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_5.4.1.zip?raw=true)
#### Big features
* Created web forum to exchange any feature requests, bug reports or ask for questions about ALV. Visit <a href="http://forum.salplachta.net"><b>forum.salplachta.net</b></a> to see how the forum looks like.
#### Features
* Added more information to the about dialog (Fact that application is free for private and also for commercial use, link to the forum and Donate button).
#### Fixes
* When any configuration file is broken, proper error message is shown and default configuration is loaded instead of exception.
#### Changes
* Dialog "Send feedback to author" now contains just link to new web forum instead of input field to send feedback directly from the application.
## 5.3.1 - 2012-07-21
###### Download: [MSI](bin/AdvancedLogViewer_5.3.1.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_5.3.1.zip?raw=true)
#### Features
* When autorefresh and autoscrolling is enabled, app jumps to last row only when last row was selected before the refresh. Otherwise stay on the same row and just show new rows from the log.
* When new log records are shown (due to manual or automatic refresh) and last row isn't selected, "Change time" field on the status bar is bold until user jumps to last row to see recent rows.
#### Changes
* Changed order of items in the "Other menu". Text of "Other" menu changed to "More". Also added link "Send feedback to author" to the About dialog.
## 5.2.1 - 2012-07-02
###### Download: [MSI](bin/AdvancedLogViewer_5.2.1.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_5.2.1.zip?raw=true)
#### Features
* Message detail window contains new extra line with date, thread, type and class information of selected row.
* When color highlighting is enable, appropriate text is also highlighted in message detail window.
* Possibility to open log file in external text editor like Notepad++ which supports also open on currently selected line in ALV. Path to text editor and command line params are configurable in ALV settings, default is Notepad.exe.
## 5.1.1 - 2012-01-21
###### Download: [MSI](bin/AdvancedLogViewer_5.1.1.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_5.1.1.zip?raw=true)
#### Features
* Added possibility to use existing instance of ALV when LogViewer is opened from command line with FileName argument. Example: 'AdvancedLogViewer.exe UseExistingInstance SomeLogFile.Log'. If any existing instance of ALV exists, SomeLogFile is opened in there.
* Added note into each filter window about '~' character. When line starts with this character condition is negated -> search for text which doesn't contain text prefixed by ~.
#### Fixes
* Fixed ugly looking line when message contains more lines - next line was partially rendered in the current one and only few top pixels were visible -> very ugly. Now is also shown '...' on end of the line when message exceed size of message column.
## 5.0.2 - 2011-12-21
###### Download: [MSI](bin/AdvancedLogViewer_5.0.2.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_5.0.2.zip?raw=true)
#### Fixes
* Fixed log adjuster on x64 Windows. Default paths to 'Programs Files' are now interpreted as 'Program Files (x86)' on 64 bit OS.
## 5.0.1 - 2011-12-18
###### Download: [MSI](bin/AdvancedLogViewer_5.0.1.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_5.0.1.zip?raw=true)
#### Big features
* Advanced Log Viewer can be PORTABLE! It means you can use it just by copy whole ALV directory without needs to install it. ALV still can be installed, then settings is saved into user's profile directory. When exists folder: "UserData" in ALV directory, all settings is saved there and ALV run in Portable mode.
#### Features
* Possibility to jump to DateTime or Line number in log file by specifying command line arguments of LogViewer. Example: "AdvancedLogViewer.exe "C:\SomeLog.log" 123"s to be interpreted will open SomeLog.log and jump there onto line 123.
* Automatic update works also in PORTABLE mode. In that case binaries are downloaded, ALV is stopped, updated by new binaries and run again.
* Added parser for OrionInstaller.log. Thanks to Denys!
#### Changes
* Changed icon for Fatal log level - now is black with red cross to better distinguish betweeen Error and Fatal
## 4.0.1 - 2011-12-11
###### Download: [MSI](bin/AdvancedLogViewer_4.0.1.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_4.0.1.zip?raw=true)
#### Big features
* New possibility to Adjust Log Level directly from the Log Viewer. User can select Config files for each Log file. Log Viewer then automatically read associated config file, show current log levels and give possibility to change them easily. This feature is accessible via new icon on the toolbar.
#### Changes
* Changed icons for log level types (warning, error, debug, ...). Each log level has different icon with different color to easily distinguish between them.
## 3.2.4 - 2011-11-13
###### Download: [MSI](bin/AdvancedLogViewer_3.2.4.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_3.2.4.zip?raw=true)
#### Changes
* Default interval for automatic update check changed from 2 days to 12 hours.
* Few minor UI changes (text corrections, tab order fixed, ...).
## 3.2.3 - 2011-11-08
###### Download: [MSI](bin/AdvancedLogViewer_3.2.3.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_3.2.3.zip?raw=true)
#### Fixes
* Icons for log item type (the icon on each line like Warning, Information, ...) disappeared.
## 3.2.2 - 2011-11-07
###### Download: [MSI](bin/AdvancedLogViewer_3.2.2.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_3.2.2.zip?raw=true)
#### Fixes
* Fixed color highlight with option "Trim text in Class column from left" enabled.
## 3.2.1 - 2011-11-06
###### Download: [MSI](bin/AdvancedLogViewer_3.2.1.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_3.2.1.zip?raw=true)
#### Features
* When application checks for updates on the web, message in status bar is shown.
* New option to trim text in Class column from left instead of right side. When true, right side of class name is always visible. By default is option enabled.
* Added possibility to send feedback directly from the application. Now you can send feature request, bug report or anything you want directly from menu: Other -> Send feedback.
#### Fixes
* When main window was set to "Stay on top", quick filter window was shown under the main window (wasn't visible)
## 3.1.3 - 2011-10-23
###### Download: [MSI](bin/AdvancedLogViewer_3.1.3.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_3.1.3.zip?raw=true)
#### Features
* Redesigned dialog which informs that New version was found, possibility to show what's new against installed version.
#### Fixes
* Fixed bug when user clicks on "Browse for Logs" in Windows explorer on long path and operating system pass this path as 8+3.
* Fixed bug when user clicks on "Browse for Logs" in Windows explorer then list of recent files were not loaded.
## 3.1.2 - 2011-10-18
###### Download: [MSI](bin/AdvancedLogViewer_3.1.2.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_3.1.2.zip?raw=true)
#### Fixes
* Fixed rare bug during saving settings for LogBrower (Exception: value can not be null).
## 3.1.1 - 2011-10-10
###### Download: [MSI](bin/AdvancedLogViewer_3.1.1.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_3.1.1.zip?raw=true)
#### Features
* Added "Browse for Logs" into Windows Explorer context menu on Folders.
* In Browse for Logs added possibility to change root folder and browse any other folder
* Browse for Logs is accessible even when no log is opened, in that case dialog with "Select folder to browse" is shown
## 3.0.2 - 2011-10-04
###### Download: [MSI](bin/AdvancedLogViewer_3.0.2.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_3.0.2.zip?raw=true)
#### Fixes
* Fixed issue during startup: Scarfsail.Common assembly is old.
## 3.0.1 - 2011-09-28
###### Download: [MSI](bin/AdvancedLogViewer_3.0.1.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_3.0.1.zip?raw=true)
#### Big features
* New tool: Browse for logs around current log. Window with tree of logs around currently opened log file. It search for all *.log* files around current log file up to defined Top Level folder (e.g. LogFiles) and show them in tree.
#### Features
* In recent files are shown only base log file names. E.g. LogFile.log instead of LogFile.log.1. This can be disabled on Settings dialog. 
* Added keyboard shortcut to show List of Recent Files: CTRL + R.
* Added keyboard shortcut for Favorive (F) and Auto Refresh (P).
* First 9 files in recent files have numbered shortcut (0-9). So when recent file list is shown, just press number which is shown before file name to open that log file.
* Added keyboard shortcuts for quick filter popup windows (M for Message, C for Class and so on).
* On filter popup window added keyboard shortcut for Enable/Disable filter (ALT+E)
* Added list of keyboard shortcuts, it's available under menu: Other -> Keyboard shortcuts
* Added possibility to disable remembering of enabled filters for next session. This option is on settings page.
#### Fixes
* Tweaked performance while log is loading.
#### Changes
* When log part isn't continuous (.log, .log.1, .log.2, ...) and some numbers missing (.log, .log.2, .log.4, ...) those parts are now shown also in log parts list.
* Refactored code responsible for keyboard shortcuts, planned possibility to define own keyboard shortcuts in some future release.
## 2.6.1 - 2011-09-11
###### Download: [MSI](bin/AdvancedLogViewer_2.6.1.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_2.6.1.zip?raw=true)
#### Big features
* Added possibility to specify Exclude filters and combine them with classic Include filters. Exclude item in filter list has to be prefixed with ~ char. Example: ~ExcludeThisWord. When you want to create include filter with ~ as first character, prefix it with \. eg: \~ThisIsIncludeFilterWith~AsFirstChar
#### Features
* Added context menu in Message detail with possibility to set/add current word as message filter.
* When Advanced Log Viewer is opened without any log, list of recent log files is shown.
## 2.5.5 - 2011-09-04
###### Download: [MSI](bin/AdvancedLogViewer_2.5.5.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_2.5.5.zip?raw=true)
#### Features
* Added some logging when application starts to investigate possible issues during app initialization.
* Added log format pattern for SWAutomationFramework.log.
#### Changes
* Changed default value for: "Select previous last item" in settings from True to False.
## 2.5.4 - 2011-04-16
###### Download: [MSI](bin/AdvancedLogViewer_2.5.4.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_2.5.4.zip?raw=true)
#### Fixes
* Fixed issue with empty lines in filter items. In case there was one empty line, filter shown all items.
#### Changes
* When filters are disabled and user clicks on some column header to specify and enable filter for that column, filters for other columns are not applied.
## 2.5.3 - 2011-04-11
###### Download: [MSI](bin/AdvancedLogViewer_2.5.3.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_2.5.3.zip?raw=true)
#### Features
* Added possibility to show / hide bottom pane with message content.
* Possibility to show list of changes in the application.
* When new update is installed, list of changes against previous version is shown.
## 2.5.1 - 2011-03-27
###### Download: [MSI](bin/AdvancedLogViewer_2.5.1.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_2.5.1.zip?raw=true)
#### Big features
* Message content extractor: Possibility to Save / Open / Copy to clipboard message content. Also possible to specify custom extractors with regex to match and extract message content and execute specific action.
#### Fixes
* Settings UI: Values for automatic updates settings wasn't saved properly to config file.
* In case log file is empty, log viewer is still trying to refresh it.
## 2.4.1 - 2011-03-20
###### Download: [MSI](bin/AdvancedLogViewer_2.4.1.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_2.4.1.zip?raw=true)
#### Features
* Internet updates: Application automatically check for new versions. There is possible to disable automatic checking and check it manually in app menu. In case new version is found, user is informed about that and LogViewer is able to download and apply that update.
* Favorites: Possibility to mark log files as Favorites. When file is marked as a Favorite, the file will be always on the top in recent files list with "yellow star" image.
* Plugins: When plugin is executed, context of log control is passed to the plugin. In the context are methods to control LogView like is GotoItem.
## 2.3.4 - 2011-03-02
###### Download: [MSI](bin/AdvancedLogViewer_2.3.4.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_2.3.4.zip?raw=true)
#### Fixes
* Exception: "InvalidArgument=Value of '-1' is not valid of 'index'" when logfile was recreated just during refresh.
## 2.3.3 - 2010-11-27
###### Download: [MSI](bin/AdvancedLogViewer_2.3.3.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_2.3.3.zip?raw=true)
#### Fixes
* Exception when log file was recreated and UI was refreshed (automatically or manually) and cursor in listview was on line number which doesn't exists yet in new log file.
## 2.3.2 - 2010-11-07
###### Download: [MSI](bin/AdvancedLogViewer_2.3.2.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_2.3.2.zip?raw=true)
#### Features
* Possibility to insert value from currently selected item into filter (useful when user wants to filter by current Thread or Type)
#### Fixes
* Wrong markers showing when only time filter was enabled
* Automatic checking of "Enabled" checkebox in Message filter when user something change (on other filters it worked)
* When filter was applied and no item was shown, in detail remained text from previously selected item.
## 2.3.1 - 2010-11-01
###### Download: [MSI](bin/AdvancedLogViewer_2.3.1.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_2.3.1.zip?raw=true)
#### Big features
* Possibility to set filter for column directly by clicking on column header
#### Features
* New possibility to show only new incomming items (useful for watching live logs) by one click or CTRL+T shortcut
* Extended UI for Date filter settings
* New settings: Select previous last item and actual last item when auto refresh
* Possibility to enable / disable filter for each column
* Indication to column header if the column is filtered
* Date fitler is autonomous - is enabled / disabled independenly on other filters.
#### Fixes
* Case when filter was enabled, auto refresh was enabled, auto scroll was enabled and new item appeared but didn't match the filter - cursor jumps to last item anyway. Now jumps to last item only when new item which match the filter appears.
* CTRL+O shortcut key
## 2.2.3 - 2010-10-13
###### Download: [MSI](bin/AdvancedLogViewer_2.2.3.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_2.2.3.zip?raw=true)
#### Fixes
* Fixed case when Total Commander isn't installed on the computer at all.
## 2.2.2 - 2010-08-08
###### Download: [MSI](bin/AdvancedLogViewer_2.2.2.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_2.2.2.zip?raw=true)
#### Features
* Settings: Possibility to integrate Advanced Log Viewer to TotalCommander as a file viewer on ALT+F3 keypress.
* Settings: When it's first run of the application, settings dialog is shown.
* Installer: New checkbox "Launch application" on last installer screen.
* Manage filters: Minor facelift changes on UI.
#### Fixes
* Application: When application is closing and some error appears during saving configuration, there wasn't possible to close application. Now is the error logged and application is closed properly.
* Main window: When autorefresh is enabled, last item from previous refresh and last item from current refresh are selected again (it didn't works in few previous versions). So there is again possible to see what was refreshed.
* Main window: Selection with SHIFT key allowed to select more than 2 items.
* Color highlight: When there isn't some column (e.g. Thread), all items were highlihted
* Custom patterns: When number of columns were changed (e.g. Thread was removed or added) exception was raised after click on "Try on current log".
* Search: When there wasn't some column (e.g. Thread) exception was raised after click on "Find" button.
## 2.2.0 - 2010-07-18
###### Download: [MSI](bin/AdvancedLogViewer_2.2.0.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_2.2.0.zip?raw=true)
#### Features
* Main window: Possibility to set autorefresh period (minimum is 200 ms).
* Manage filters: Added groups of filters (the same as is in manage color highlights dialog).
* Main window: When user double clicks on some line, it's the same as click on Bookmark button.
* Main window: Added icon for "Auto refresh" button instead of text
* Main window: Removed button "Auto scroll", currently is it on settings page and is applied only when "Auto refresh" is enabled.
* Main window: Time span between two selected items is shown as hh:mm:ss.fff.
* Main window: Two item selection improved - first item always keep selected and as second is always selcted the current.
#### Fixes
* Main window: When current log file was deleted (e.g. when was rolled out), exception "RetrieveVirtualItem" was raised.
* Manage highlights - when dialog was closed by X, current state was saved.
* Main window: CTRL+END and CTRL+HOME in the list of logs works correctly now.
## 2.1.0 - 2010-11-07
###### Download: [MSI](bin/AdvancedLogViewer_2.1.0.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_2.1.0.zip?raw=true)
#### Features
* Main window: When user selects two lines (with CTRL), time span between them is shown in status bar.
* Main window: Manage filters and Manage highlights buttons are now represented by an icon instead of text.
* Find dialog: All settings in search dialog (last text, checkboxes, ...) are saved to settings file and loaded on next session.
* Find dialog: Added possibility to choose if user wants to search from current position or in all items regardless of the current cursor position.
* Find dialog: When searched text isn't found for first time from the current position, status text is orange and is possible to search from beginning. When text isn't found from the beginning, status text is red and there is appropriate information about that.
* Find dialog: When user search again from beginning / end, main window doesn't blink / refresh anymore.
* Manage highlights: Added embedded color grid picker on the form. No need to show color dialog, select color and click OK anymore. Now it could be done by one click.
#### Fixes
* Main window: When main form is stay on top other windows (like Manage Filters) was shown under main window.
* Main window: When user clicks on Bookmark button and current line was already bookmarked, next empty bookmark was set instead of reset bookmark for this line.
* Main window: Shortcut CTRL + H to toggle color highlights didn't works.
* Main window: When user set / reset filter, last selected item should be selected. When isn't visible, first next item is selected.
* Manage highlights: When some text was selected (SelectionLength > 1), colors was saved incorrectly or everything was white.
## 2.0.0 - 2010-06-20
###### Download: [MSI](bin/AdvancedLogViewer_2.0.0.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_2.0.0.zip?raw=true)
#### Features
* Main window can "stay on top" (switch is on the toolbar).
* Added Settings dialog (available under Other -> Settings)
* Ability to set if application will exit when user press ESC key
* Added some other settings from main menu
* 
      Added bookmarks:
      - Button available on the toolbar - press the button to assign first free bookmark on current line. Dropdown menu to view all the bookmarks.
      - Press CTRL + SHIFT + Number to toggle bookmark on current line
      - Press CTRL + Number to goto bookmark with the number
      - The bookmark is is shown on appropriate line before DateTime text.
    
* 
      Reworked Find text functionality:
      - Find function has own window, removed for someone confusing search boxes from main window.
      - Find dialog isn't modal - when isn't focused, transparency of the window is set to 75%.
      - Ability to search as Regular Expression !
      - Ability to search with Case sensitive option
      - Reworked search algorithm
      - Two items selection fix (now is selected only item which is found, previously selected item isn't selected henceforth).
      - When there is nothing found and user select to search from the beginning again and there is still nothing found, original item keep selected.
      - Searched text is saved into a config file and then offered in combo box on the search dialog.
    
* Few minor UI changes (texts, graphics).
#### Fixes
* Fixed Jump to item functionality (two items was selected instead of one)
## 1.8.2 - 2010-06-13
###### Download: [MSI](bin/AdvancedLogViewer_1.8.2.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_1.8.2.zip?raw=true)
#### Features
* Added possibility to show / hide side panel with markers (errors, warnings). It's located under menu: Other -> Show Markers.
* Installer shows version of the product in the caption.
#### Fixes
* When viewed log file is deleted, refresh doesn't show any error message but it cleanup the list of logs and in status bar shows text that file doesn't exists. This could happen during log renaming by log4net and when auto refresh is enabled - before the fix error was appear.
* Fixed error with item numbering when log was updated (Error in log: Error while showing markers: System.ArgumentException: An item with the same key has already been added.).
* Finally fixed flickering during contents refreshing !!! No more flickering when log is updated, scrolled or the rest of the log is asynchronously loaded.
## 1.8.1 - 2010-05-30
###### Download: [MSI](bin/AdvancedLogViewer_1.8.1.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_1.8.1.zip?raw=true)
#### Features
* Added logging of the application, you can find logs under: %ProgrammData%\AdvancedLogViewer\Logs\. For each instance of the LogViewer is created one log file whose file name contains process id of the instance.
* Removed license confirmation from the installer.
* Added version info on welcome page in the installer.
#### Fixes
* Fixed autoscroll when user clicks on Filter or Color highlights buttons.
## 1.8.0 - 2010-05-23
###### Download: [MSI](bin/AdvancedLogViewer_1.8.0.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_1.8.0.zip?raw=true)
#### Features
* Added Text Diff feature - now is possible to diff texts between two log items (in defined external diff tool - e.g. p4merge.exe, for configuration goto: Other -> External diff tool settings)
* Added custom patterns editor. It's rich GUI where is possible to define custom pattern parsers for log files with ability to preiew edited pattern on current log. (It's located under menu: Other -> Manage parser patterns)
* When there si no suitable pattern parser found, pattern editor is shown with ability to preview edited pattern on the the log file for which wasn't found suitable pattern.
#### Fixes
* Fixed issue when highlighting items without Type or Thread.
* Renamed "Live update" to "Auto refresh" (live was confusing, because of live application update over the web).
## 1.7.0 - 2010-05-16
###### Download: [MSI](bin/AdvancedLogViewer_1.7.0.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_1.7.0.zip?raw=true)
#### Features
* Filenames in patterns now can include wildcards (*) (in previous versions were compared only as "Contains")
* Added CustomParserPatterns.def file which is designed for user's pattern definitions. ParserPatterns.def shouldn't be edited by an users, because could be rewritten during application upgrade.
* In case there is not suitable parser pattern, appropriate message is shown.
* Setting files (Colorhighlight, Settings, Filters, ...) are now in CommonApplicationData\AdvancedLogViewer (Vista/W7: ProgramData\AdvancedLogViewer ; XP/older: Documents and Settings\All Users\Application Data\AdvancedLogViewer) because when UAC is enabled then into Program Files directory (where setting files were in the past) can write only Administrators.
* Improved performance for log loading (about 10% since previous version)
* Main form is shown on center of the same screen as is the parent application window (Explorer, Total Commander, ...)
* Filter is saved after each change and loaded after app start (same as for color highlight definition) .
* Color highlighting: Text is now compared for Thread and Type text too.
* When filter is enabled, information about shown / total items in status bar is bold.
#### Fixes
* Fixed issue during log refresh (especially for periodic refresh)
* Fixed issue when first line begins with something else than time (e.g. swAlert.log in Orion 2010.1)
* Fixed issue with Autorefresh after application start.
## 1.6.2 - 2010-05-09
###### Download: [MSI](bin/AdvancedLogViewer_1.6.2.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_1.6.2.zip?raw=true)
#### Features
* Simpified UI for managing filters and highlights
* Added ability to revert filter (show all what doesn't match current conditionals)
## 1.6.1 - 2010-04-25
###### Download: [MSI](bin/AdvancedLogViewer_1.6.1.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_1.6.1.zip?raw=true)
#### Features
* Simple installer in WIX
* Copy all files to desired folder and create shortcuts in Startmenu.
* When you run older version of installation, downgrade is blocked.
* When you run newer version of installation, product is automatically updated.
#### Fixes
* Fixed log merge feature (bad order of logs to merge)
* Fixed loading other parts of logs when .LOG file is opened
* Some minor UI improvements
* Fixed issue with side panel (wrong thread synchronization to UI)
* Internal code changes (cleanup, refactoring)
## 1.5.0 - 2010-03-22
###### Download: [MSI](bin/AdvancedLogViewer_1.5.0.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_1.5.0.zip?raw=true)
#### Features
* New clickable side panel with color markers representing errors and warnings in the log.
* Improved performance for showing log type icons
#### Fixes
* Fixed enabling/disabling buttons after log refresh
## 1.4.3 - 2010-03-21
###### Download: [MSI](bin/AdvancedLogViewer_1.4.3.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_1.4.3.zip?raw=true)
#### Features
* Merging partial log files (.1, .2, ...) into one file
* Show all parts of log files (.1, .2, ...) and open it by one click
* New shortcuts: CTRL+Left and CTRL+Right shows previous/following partial log file (.1, .2, ...)
#### Fixes
* Memory usage is less about 50% for large logs
* CPU usage is lower during loading (about 20% faster loading)
* Fixed aborting during log file loading
## 1.3.2 - 2010-03-11
###### Download: [MSI](bin/AdvancedLogViewer_1.3.2.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_1.3.2.zip?raw=true)
#### Features
* Added information when searched text isn't found, possibility to search from start/end of log
#### Fixes
* Fixed minor issues with autoscroll while loading
* Improved loading performance (especially for long inner texts)
## 1.3.1 - 2010-03-09
###### Download: [MSI](bin/AdvancedLogViewer_1.3.1.msi?raw=true) or [ZIP](bin/AdvancedLogViewer_1.3.1.zip?raw=true)
#### Features
* First public version. No list of changes against previous version.
