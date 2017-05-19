# Unity-Stranded
A Unity survival RPG and final project for CMSC425

Name: Brian Fitzgerald
CMSC425 Final Project

# A. Required Elements
* Game starts from Entry Scene
* Move character with combined WASD keys and mouse controls
* Move the mouse to move the camera, use the scroll wheel to zoom in/out
* SPACE to jump
* 'C' key to crouch
* Left click to interact with the world when prompted in the "Actions" box
* The goal is to survive for as long as possible
* The lower right displays a day counter and accelerated clock in military time
* The game ends when the player's health bar reaches zero
* Health decreases when the stamina bar is zero, or from adverse effects of berry consumption
* Stamina decreases from a combination of constant hunger, moving, and climbing
* Eating berries can affect health and stamina, positively or negatively
* Berries respawn every five minutes in "real" world time

# B. Additional Elements
* Used Unity terrain editing tool to build mountains, valleys, etc.
* Used Unity fog for atmospheric effects
* Used Unity Canvas and UI tools for the heads-up-display
* Used Unity Standard Asset Water2 for lake and stream
* Used Unity Standard Asset Vehicle/AircraftPropeller for crashed jet
* Used Unity Standard Asset ThirdPersonController for playable character control and animations
* Used Unity Standard Asset SpeedTree for trees
* Used Unity Standard Asset TerrainAsset for grass and dirt
* All scripts written or partially written by me are located in Assets/Assets/Scripts

# C. Known Issues
* I used the Unity Scene Manager library, which has previously had issues on newer versions of Unity but works fine in my version
* Camera is allowed to position itself below world terrain, can look awkward
* No swimming animations, character just walks around under water
* Lighting doesn't change with time, because our guy is in Northern Canada in summer!

# D. External Resources
* Used stock character "Swat" from Adobe Mixamo
* Used "Wispy Skybox" https://www.assetstore.unity3d.com/en/#!/content/21737
* Used "Yughes Free Bushes" https://www.assetstore.unity3d.com/en/#!/content/13168
* Used "Natural Tiling Textures" https://www.assetstore.unity3d.com/en/#!/content/35173
* Some code for fading text on entry scene obtained from https://forum.unity3d.com/threads/fading-in-out-gui-text-with-c-solved.380822/
* Some code for CameraController2 obtained from http://wiki.unity3d.com/index.php?title=MouseOrbitImproved
* My video demo https://www.youtube.com/watch?v=rkgP8sRMmFY
