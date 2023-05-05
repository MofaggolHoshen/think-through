```
Windows Registry Editor Version 5.00

[HKEY_CLASSES_ROOT\Directory\Background\shell\wt]
 @="Open Windows Terminal here"

[HKEY_CLASSES_ROOT\Directory\Background\shell\wt\command]
 @="C:\\Users\\m.hoshen\\AppData\\Local\\Microsoft\\WindowsApps\\wt.exe"
```

Note: Replace {your-username} in the above code with your Windows username.

1. Save the file with a .reg extension, for example open-terminal-here.reg.

2. Double-click the saved .reg file to import the settings into the Windows Registry.

3. Now when you right-click on a folder in File Explorer, you should see an option to "Open Windows Terminal Here".

In Widows Terminal Settings, give starting directory ("startingDirectory": ".")

```
"profiles": 
    {
        "list": 
        [
            {
                "commandline": "%SystemRoot%\\System32\\WindowsPowerShell\\v1.0\\powershell.exe",
                "guid": "{61c54bbd-c2c6-5271-96e7-009a87ff44bf}",
                "hidden": false,
                "name": "Windows PowerShell",
                "startingDirectory": "."
            },
        ]
    }
```
