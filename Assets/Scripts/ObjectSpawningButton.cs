using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawningButton : MonoBehaviour
{
    public SpawnManager spawnManager;
    public int index;

    private void Start()
    {
        spawnManager = GameObject.FindAnyObjectByType<SpawnManager>();
    }

    /// <summary>
    /// Spawn the associated object in front of the camera.
    /// </summary>
    public void SpawnObjectInFront()
    {
        if (spawnManager != null)
        {
            spawnManager.SpawnObjectInFrontOfCamera(index);

        }
        else
        {
            Debug.LogError("SpawnManager not found in scene. Must have a game object with SpawnManager script");
        }
    }

}
