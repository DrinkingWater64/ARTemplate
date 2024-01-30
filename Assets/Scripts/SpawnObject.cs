using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public SpawnManager spawnManager;
    public int index;
    public void SpawnObjectInFront()
    {
        spawnManager.SpawnObjectInFrontOfCamera(index);
    }
}
