# JoyKeyMapper

###### JoyKeyMapper is a small C#-based tool for mapping joystick buttons to keyboard inputs.
###### Setup of mappings is done in a configuration window.

[Latest Release](https://github.com/caanders/JoyKeyMapper/releases/latest)

### Installation
Simply download the current version of JoyKeyMapper, unpack the archive to a location of your choice and run JoyKeyMapper.exe.
In case any application is not receiving key presses try running JoyKeyMapper as administrator.

### Usage
The main window  looks like this:

![mainscreen](https://github.com/caanders/JoyKeyMapper/blob/docs/docs/mainscreen.PNG)

Press "Configuration" to open the configuration window:

![config](https://github.com/caanders/JoyKeyMapper/blob/docs/docs/config1.PNG)

To add one or more button mappings press "Read Button".

![config](https://github.com/caanders/JoyKeyMapper/blob/docs/docs/config2.PNG)

Press one or more buttons on your joystick. Then press "Read Button" again to obtain the input.

![config](https://github.com/caanders/JoyKeyMapper/blob/docs/docs/config3.PNG)
<br>All new and existing entries for pressed buttons are selected.

Press "Read Keys" and press any key combination. Make sure to press on key after the other. Otherwise windows will repeat key presses which will be recognized as many single key presses.

![config](https://github.com/caanders/JoyKeyMapper/blob/docs/docs/config4.PNG)

Press "Read Keys" again to obtain input.

![config](https://github.com/caanders/JoyKeyMapper/blob/docs/docs/config5.PNG)

Save the current configuration by pressing "OK". A message will appear, indicating if saving was succesfull. This message closes automatically after a few seconds.
Delete will delete all selected entries.
Cancel will discard all changes since opening the configuration screen.

To start the mapping of configured buttons press "Start/Stop Mapping" on the main window.

![mainscreen](https://github.com/caanders/JoyKeyMapper/blob/docs/docs/mainscreen2.PNG)

Two User Options are availabe:
* minimize to tray<br>
  minimizing to tray instead of task bar
* auto startup<br>
  after starting the application, mapping ist started automatically