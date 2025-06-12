Fabio Choi
fchoi30@gatech.edu

-----------------------

Game Menu Scene Name: "GameMenuScene.unity"
Play Scene Name: "demo.unity"

This is milestone 2 Physics

# Confirmed: 

1. There are only 4 folders under the top-level folder, with 
nothing except the readme alongside.
2. There are no Visual Studio solution or project files.
3. There is a single, correctly-named readme.
4. There are two builds, with one marked with an UNTESTED, 
extension-less file.

# Implemented:
1. Pause script is disabled from M2
2. Game Start Menu has dedicated scene:
  - Overlay:
    - Menu Panel is centered but does not fill the screen 
    - Contains Start Game button
    - Contains Exit Game button
  - Camera Background:
    - Contains post processing effects (`Grain and blurry`)
3. Working in game Menu:
  - Overlay:
    - Overlay is centered but does not fill the screen
    - Contains Restart Game button
    - Contains Exit Game button
  - Panel responds to Esc button
  - Game pauses when menu is opened
4. Collectable ball that only SomeDude_RooMotion can collect
  - Can be thrown and attached to hand (EXTRA CREDIT)
```
Head towards the back of the map to the pink spheres to collect object cubes
The objects can be thrown and held in the hand of the player with the left control button
```
5. Trigger-based animated prefab object that is place in at least 3 locations
  - Object is prefabed
  - Object is animated when player is in range
  - Object resets when player leaves range
  - Transitions are smooth
```
Head towards the back of the map to the Black cubes placed around the back and they should start rotating and expanding/shrinking when close.
  ```
  - It will stop animation when further away.
6. Mentioned above, but player can also throw the object that is collected (pink)
  - Triggered with left control button (see above)
