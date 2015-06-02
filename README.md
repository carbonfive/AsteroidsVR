# AsteroidsVR

This is an example Virtual Reality project for Google Cardboard, built with Unity. It was part of a workshop for Droidcon Berlin 2015

Credit for the assets go to [Unity's Space Shooter project][unity-space-shooter] and [1001 Free Fonts][1001-free-fonts].

## Building From Scratch

While this repo contains the complete code, the following are instructions to build the game from scratch using only assets we've provided.
These assets are:

* [AsteroidsVRAssets.unitypackage][AsteroidsVRAssets] - containing the assets to make the game
* [CardboardSDKForUnity.unitypackage][CardboardSDKForUnity] - containg the Google Cardboard support

### Simple Mechanics

This section goes over the steps covered in the workshop to see demonstrations of core VR concepts.

#### Setting the Scene

This is just the basic setup of a Unity project.

1. Create a new Unity3D project.
1. Select the Main Camera and then in the Inspector, set it's position to the Origin (0, 0, 0)
1. Save the scene in a new Scenes folder:
  1. Click File > Save scene as ...
  1. Create a new folder called Scenes
  1. Save scene as Scene01

#### Seeing Asteroids and Space

Now, while a new project starts with a light and camera, there is really nothing to see at first.
Here's how to bring in some pre-built objects into the game world.

1. Import AsteroidsVR Assets by clicking Assets > Import Package > Custom Package
1. Select AsteroidsVRAssets.unitypackage
1. Import all of the assets.
1. Drag the Asteroid prefab from the Prefabs folder in the Projects Pane to the scene Hierarchy. This creates a new instance in your scene.
1. Select the Asteroid in the Hierachy, and then in the Inspector pane, check to Activate RandomRotator script. This contains the code to constantly
rotate the asteroid around a random axis.
1. Switch to Game view (Click the Game tab) and press play. There should be a rotating Asteroid in your game.
1. Save the scene!
1. Switch to Scene view
1. Inside of the Materials folder of the Project pane, there should be 2 skyboxes. Pick your favorite and drag it into the Scene view NOT the Hierarchy and not on top of any object.
1. To look around in Scene view, you can scroll to zoom, or press Alt + click and drag to rotate. The stars and nebula should rotate around you like a distant background.
1. Save the scene!

#### Make it VR

To turn the game into a VR experience is very easy; in fact it may be the easiest part of building this game.
Most headset libraries provide drop-in solutions to render the stereoscopic view of your game and for manipulating the camera to match
the user's head tracking. Here's how to do it for Google Cardboard using just one of their
built in solutions.

1. Import CardboardSDKForUnity by, again, clicking Assets > Import Package > Custom Package.
1. Select the CardboardSDKForUnity.unitypackage
1. Import all of its assets. You may get a warning about the package
   containing referencing outdated APIs, and an offer to have them
   automatically updated. You can accept this offer safely.
1. From the Cardboard > Prefabs folder of the assets pane, drag the CardboardMain prefab into the Hierarchy.
1. Delete the original Main Camera
1. Switch to Game view, and press play. You should see a stereoscopic view.
1. Simulate the head tracking by holding the Alt/Option key and moving the mouse.
1. Save the Scene!

#### Run it on the Device

Let's get the app running on your actual Android device.

__NOTE__: Be sure you:
* Have Android Studio and its Commandline tools installed.
* The latest APIs for your phone downloaded through the Android SDK Manager
* Your device has developer mode enabled.
* Its connected and powered to your development system.

1. Select File > Build Setting
1. Android as Platform
1. Click Player Settings, to open them in the Inspector.
1. Under “Other Settings” set to an appropriate value (`com.carbonfive.asteroidsvr` for example).
1. Under “Resolution and Presentation”, select Landscape Left as the
   Default Orientation
1. Back in the Build Setting window, click  “Build and Run” to name your .apk file
1. The game should launch on your device. Slot it into your headset and enjoy.
1. Also, save the scene!

#### Interaction: Blowing up Asteroids!

We're going to now have the asteroid blow up when you look directly at it and pull the Carboard
trigger. This is done by casting a ray from the camera, and asking the asteroid's collision detection
if it intersects with it.

1. Click to select the Asteroid in your Hierarchy
1. In the Inspector for the Asteroid, check to activate the AsteroidController Script component. It handles
ray casting and collisions, the detection of the trigger, and removing the asteroid from the scene with an explosion.
1. Inside the AsteroidController Script, uncomment lines 17, 19 & 20 (but not 18) so it should like this:

    ```cs
          if (Cardboard.SDK.Triggered && isLookedAt) {
    //      ScoreManager.score += 5;
            Instantiate (explosion, hit.transform.position, hit.transform.rotation);
            Destroy (gameObject);
          }
    ```

1. Save the scene and play the game preview. Click on the screen to simulate a trigger pull to blow up the asteroid!
1. Build and run to the device and put it in a real headset.

#### Creating a Heads Up Display (HUD)

Best practice says you should have a targeting reticle (crosshairs) so users know what they
can interact with. This also means learning how to display 2D in a stereoscopic 3D display.

1. Add HUDCanvas prefab to the Hierarchy as a child of CardboardMain > Head > MainCamera. It
has a preconstructed UI set to render in "Worldspace" so that it's treated like a 3D object and
appears in both stereo views. Also, the UI elements under the object have scripts that handle
turning the crosshairs red and white.
1. To make the score counter work, inside the AsteroidController script uncomment line 18:

```cs
  ScoreManager.score += 5;
```
1. Save the scene and play the preview or build-and-run the game on your device. Notice how
the score and crosshairs stay in view, and the score increases when you blow up the asteroid.

### Completing the Game

This section was not covered in the workshop and goes over what is needed to complete the game.

#### Running the Game

In Unity, we usually add an object with only a script to run the actual game logic of the scene.
In our case, this is the Game Controller, which will spawn new asteroids on start and keep spawning
every 10 seconds. Becasue of this, we no longer need an asteroid in our scene, but instead have
to connect the GameController to the original Asteroid prefab, which needs all its scripts activated.

1. Delete the Asteroid from the Hierarchy
1. In the Project Pane, select the Asteroid pre-fab within the Prefabs folder.
1. Activate all the scripts on the Asteroid pre-fab in the Inspector.
1. Drag the GameController prefab to the Hierarchy. It contains the code to spawn 6
   asteroids at the beginning of the game, and one more every 10 seconds.
1. Save the game and run it. You see many Asteroids heading towards you. Blow them up to rack up the points.
Don't worry if one gets too close; you can't lose ... yet!

#### It's Game Over, man!

In order for the game to end, we need to detect a collision between the Main Camera and any asteroid.

1. In the Hierarchy pane, open the CardboardMain tree until you can select the Main Camera.
1. In the Inspector, click on Add Component and start typing "Sphere Collider". Select it when the option becomes available.
1. In the Sphere Collider component properties, set the radius to 1.2
1. Now in the GameController script, uncomment the body of the Update app. This restarts the level when the Cardboard is triggered while the game is over by reloading the scene.
1. To stop the Asteroids from moving when the game is over:
  1. In the AsteroidController script, uncomment lines 8 and 22
  1. In the AsteroidMovementController script, uncomment lines 13 and 18
1. Hit play and watch the asteroids move towards the camera. When one of them gets too close, it's Game Over.
1. Save the scene!

Congratulations! You’re done.

[unity-space-shooter]: https://unity3d.com/learn/tutorials/projects/space-shooter
[1001-free-fonts]: http://www.1001freefonts.com/megafont.font
[AsteroidsVRAssets]: http://www.c5vr.com/presentations/downloads/AsteroidsVRAssets.unitypackage
[CardboardSDKForUnity]: https://github.com/googlesamples/cardboard-unity/blob/master/CardboardSDKForUnity.unitypackage?raw=true
