# Open Terminal on Mouse Ringht Click

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

### Add image

1. Open the Run dialog box by pressing Win + R shortcut. In the blank field, copy and paste the below path and press Enter.

```
%USERPROFILE%/AppData/Local/
```

2. In this folder, right-click and select “New → Folder” to create a new folder. Name the folder as “WTerminal“.

3. Next, open the “Registry Editor” by searching for it in the start menu. In the Registry Editor, go to the following folder.

```
HKEY_CLASSES_ROOT\Directory\Background\shell\wt
```

4. Right-click on the right-panel and select the “New → String Value” option. Name the value as “Icon“.

5. Double-click on the “Icon” value. In the value data field, copy and paste the below path and click on the “Ok” button.

```
%USERPROFILE%/AppData/Local/WTerminal/terminal.ico
```

That is it. Close the registry editor. From now on, you should also see the terminal icon right next to the “Open Windows Terminal here” option.