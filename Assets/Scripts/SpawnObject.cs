using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] GameObject spawnObject;
    [SerializeField] float distance = 4f;

    public void SpawnObjectInFront()
    {
        Camera cam = Camera.main;
        Vector3 newLoc = cam.transform.position + cam.transform.forward*distance;
        GameObject spawnedObj = Instantiate(spawnObject, newLoc, Quaternion.identity);
        
    }
}
