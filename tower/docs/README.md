# Unity VR - Bow And Arrow 

If you would like to create your own VR Bow and Arrow expereince you can find the assets here.

## Setting UP Project

1. Create a new 3D Project
    * Click `New Project`, choose 3D Core, and name the Project VRarchery

2. Install Install XR Interaction Toolkit
    * In `Window` open `Package Manger` Under the `+` choose `Add package from git URL...`
    * In the text box type `com.unity.xr.interaction.toolkit` and `com.unity.xr.management` click `Add`. You will get a Popup click `Yes`.
    * Click on `XR Interaction Toolkit` and under `Samples` choose `Starter Assets` and Import the starter Assets

3. Install XR Plug-in Management
    * In `Edit` choose `Project Settings` and under `XR Plug-in Management` click install.
    * Under `XR Plug-in Managemet` on the left choose `OpenXR` and under `Interaction Profiles` chose the `+` icon then choose the profiles for your headset choices (i.e Oculus - Oculus Touch Controller Profile)

4. Add XR Origin
    * In the `Hierarychy` panel right click and select `XR` and choose `XR Origin (VR)` (should be the last opotions)
    * On the left hand sid, left click `XR Origins (XR Rig)`. If you look to the right hand side (in your `inspector` tab) you should find `Input Action Manager` then in  the section `Action Assets` left click the `+` icon and add `DefaultInputActions`
    * Still under the `XR Origns (XR Rig)` left click `Left Contoller` to open up the `XR Controller(Action-based)` in the Inspector. Next next to the docs icon (question mark) click the icon, which will bring up `Selecte Preset ` popup and type `left` and choose `XRI LeftHand...`. Repeat for the `Right Controller`.

5. Test
    * If everything went well you should to plug in your VR headset and click the play in the top middle of the tab

