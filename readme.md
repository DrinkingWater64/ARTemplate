# AR Template
An AR template application by Unity, where you can place a object and take a picture which will be saved in your device. Built with Unity version 2022.3.1f1. 

## Third Party Packages
**Native Gallery for Android & iOS**
By default, Unity does not save pictures in gallery for both android and IOS. This plug in handles all the permissions required and save images directly in the Gallery instead of the AppData directory. This plugin also provides functionalities for making albums and naming options.  
[Native Gallery for Android & iOS | Integration | Unity Asset Store](https://assetstore.unity.com/packages/tools/integration/native-gallery-for-android-ios-112630)
[Documentation](https://github.com/yasirkula/UnityNativeGallery)

## Installation
Download the latest release or clone the repository and build the application. 
## How to
For full example refer to SampleUI scene.

**a. Add a new object**
Right click in the asset browser `Create -> ScriptableObjects -> PrefabIconData`. In the new created object. Put the game object you want to spawn in `Prefab` field and the corresponding Icon in the `Icon` field. 
Have a empty game object which will be the spawn manager. Attach the script `SpawnManager.cs` in this game object or use the `ObjectSpawnerManager` prefab. This will handle all the spawning functionalities.  In the script, add the new scriptable object you made to list of SpawnManager.
