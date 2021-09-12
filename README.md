# Project Glass
I've been spending time on learning native Windows APIs, hooks and other low level stuff. This project is an intermediate result of my research and prototyping and supposed to bring some native Windows functionality to Unity appications.
There are the following modules:

* Windows Module
* Keyboard Input Module
* Mouse Input Module

## Windows Module
This module is responsible for tracking existing windows so you can:
*  Iterate over them
* Read/Write access to position
* Read/Write access to size
* Change window's topmost status
* Change window's transparency status
* Change window's click through status
* Focus
* Minimize
* Restore
* Maximize
* Opened/Closed callbacks

## Keyboard Input Module
This module is responsible for tracking system wide keyboard events:
* Key down event
* Key up event
* Check whether `UnityEngine.KeyCode` is pressed

## Mouse Input Module
This module is responsible for tracking system wide mouse events:
* Button down event
* Button up event
* Check whether mouse button is pressed
* Read/Write access to cursor position

# A bit more details about
Every Project Glass module is quiet independent and can be enabled/disabled separately. You can use the only functionality you need with no extra overhead from needless modules.
Also Project Glass modules update is injected directly into Unity Player Loop right before `MonoBehaviour`'s `Update` so you always have a fresh data based on native hooks and callbacks. Thus you don't need to drop any prefab into your game scene.

## Render on top of Windows desktop
With Project Glass you can bring any of your game/app ideas right to the Windows desktop. In order to achieve such behaviour add the following code to e.g. `Awake` method of your `MonoBehaviour` script:
```
#if !UNITY_EDITOR

        ProjectGlass.Windows.MainWindow.SetTransparent(true);
        ProjectGlass.Windows.MainWindow.SetTopMost(true);
        ProjectGlass.Windows.MainWindow.SetClickThrough(true); // optionally

#endif
```
Right, this won't work in Unity Editor so it make debugging process a bit more complicated.
To quickly check this out you can build project with demo scene included and if everything goes well you'll see a default Unity cube on top of you desktop.
P.S. There might be the case that you'll need to disable `Use DXGI Flip Model Swapchain for D3D11` option in `Project Settings` > `Resolution and Presentation` in order to your app transparency to work properly.