using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSelectMenu : MonoBehaviour
{
    public List<GameObject> buttonObjects;
    public SpawnManager spawnManager;
    private int startIndex = 0;
    private int endIndex = 0;


    private void Start()
    {
        spawnManager = GameObject.FindAnyObjectByType<SpawnManager>();
        if (spawnManager == null)
        {
            Debug.LogError("SpawnManager not found in scene. Must have a game object with SpawnManager script");
        }
        startIndex = 0;
        endIndex = buttonObjects.Count-1;
        SetUpButons();
    }


    /// <summary>
    /// Set up buttons in the menu based on the current startIndex and endIndex.
    /// </summary>
    public void SetUpButons()
    {
        for (int i = startIndex; i <= endIndex; i++)
        {
            int buttonIndex = i % buttonObjects.Count;
            buttonObjects[buttonIndex].GetComponent<Image>().sprite = spawnManager.spawnables[i].icon;
            buttonObjects[buttonIndex].GetComponent<ObjectSpawningButton>().index = i;
        }
    }

    /// <summary>
    /// Switch to the next set of items in the menu.
    /// </summary>
    public void Switch()
    {
        startIndex = ((startIndex + buttonObjects.Count) % spawnManager.spawnables.Count);
        endIndex = ((endIndex + buttonObjects.Count) % spawnManager.spawnables.Count);
        SetUpButons();
        Debug.Log(startIndex + " " + endIndex);
    }
}
