using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] float distanceFromCamera = 1f;
    public List<SpawnableObjs> spawnables;
    private GameObject[] _spawnedObjects;
    
    private void Start()
    {
        _spawnedObjects = new GameObject[spawnables.Count];
    }

    public void SpawnObjectInFrontOfCamera(int index)
    {
        if (_spawnedObjects[index] == null)
        {
            DespawnObjects();
            Camera cam = Camera.main;
            Vector3 newLocation = cam.transform.position + cam.transform.forward * distanceFromCamera;
            _spawnedObjects[index] = Instantiate(spawnables[index].prefab, newLocation, Quaternion.identity);
        }
        else
        {
            DespawnObjects();
        }

    }

    public void DespawnObjects()
    {
        foreach (GameObject spawnedObject in _spawnedObjects) {
            if (spawnedObject != null)
            {
                Debug.Log(spawnedObject.name);
                DestroyImmediate(spawnedObject);
            }
        }
    }
}
