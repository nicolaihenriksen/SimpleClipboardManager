# Archived! Old and out-dated
This repository was a fun little hobby project done many years ago. No longer relevant and thus archived.

# Simple Clipboard Manager

Available from the [Windows Store](https://www.microsoft.com/store/apps/9p68k1bl0m7g).

Simple implementation of a clipboard manager which allows you more control over the strings you copy and paste. Selective strings can be marked as favorites and/or as passwords (see sections below).
When activated by the selected hotkey, the following dialog is displayed:

![](https://github.com/nicolaihenriksen/SimpleClipboardManager/blob/master/Screenshots/Screenshot1.png?raw=true)

This list displays all the strings that have been copied to the clipboard. You can then re-arrange, mark as password, delete or paste any given item in the list using the given key combinations.

The title bar buttons allow you to: Clear the list, open the settings dialog, or hide the paste dialog.

#### Settings
The settings dialog allows you to control the functionality and visual representation of the clipboard manager:

![](https://github.com/nicolaihenriksen/SimpleClipboardManager/blob/master/Screenshots/Screenshot2.png?raw=true)

#### Mark as password
The "*Mark as password...*" option, available via key combination or right-clicking on the item, will allow you to indicate that the given item is a password:

![](https://github.com/nicolaihenriksen/SimpleClipboardManager/blob/master/Screenshots/Screenshot3.png?raw=true)

Here you have the option of simply masking the password (i.e. it will display 8 asterisks instead of the actual password), or giving the password item an arbitrary logical name to help you identify which password you've copied.

__***Disclaimer***__
As indicated in the screenshot, password items simply have their visual representation modified to hide the actual password. The copied string still resides in memory and optionally on disk (see the *Settings* section). Use at your own risk!

#### Mark as favorite
The "*Mark as favorite...*" option, available via key combination or right-clicking on the item, will allow you to mark certain items as favorites for easier pasting (i.e. CTRL+SHIFT+F1-F12)

![](https://github.com/nicolaihenriksen/SimpleClipboardManager/blob/master/Screenshots/Screenshot4.png?raw=true)

Here you have the option of associating the selected item with a given favorite key (F1-F12). This can be used for quick pasting; see below.

#### Quick pasting
To quickly paste something from the Clipboard Manager, you can use CTRL+SHIFT+1-9 as a shortcut to paste the n'th (1 through 9) element in the list based on the display order.
As the display order changes every time something is copied to the clipboard, it is probably desirable to use CTRL-SHIFT+F1-F12 which will paste the favorite item stored on the given favorite key (F1-F12).
