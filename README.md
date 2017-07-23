# Simple Clipboard Manager

Simple implementation of a clipboard manager which allows you to copy/paste multiple strings.
When activated by the selected hotkey, the following dialog is displayed:

![](https://github.com/nicolaihenriksen/SimpleClipboardManager/blob/develop/Screenshots/Screenshot1.png?raw=true)

This list displays all the strings that have been copied to the clipboard. You can then re-arrange, mark as password, delete or paste any given item in the list using the given key combinations.

The title bar buttons allow you to: Clear the list, open the settings dialog, or hide the paste dialog.

#### Settings
The settings dialog allows you to control the functionality and visual representation of the clipboard manager:

![](https://github.com/nicolaihenriksen/SimpleClipboardManager/blob/develop/Screenshots/Screenshot2.png?raw=true)

#### Mark as password
The "*Mark as password...*" option, available via key combination or right-clicking on the item, will allow you to indicate that the given item is a password:

![](https://github.com/nicolaihenriksen/SimpleClipboardManager/blob/develop/Screenshots/Screenshot3.png?raw=true)

Here you have the option of simply masking the password (i.e. it will display 8 asterisks instead of the actual password), or giving the password item an arbitrary logical name to help you identify which password you've copied.

__***Disclaimer***__
As indicated in the screenshot, password items simply have their visual representation modified to hide the actual password. The copied string still resides in memory and optionally on disk (see the *Settings* section). Use at your own risk!