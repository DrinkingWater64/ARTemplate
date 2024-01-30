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
        startIndex = 0;
        endIndex = buttonObjects.Count-1;
        SetUpButons();

    }

    public void SetUpButons()
    {
        for (int i = startIndex; i <= endIndex; i++)
        {
            buttonObjects[i%3].GetComponent<Image>().sprite = spawnManager.spawnables[i].icon;
            buttonObjects[i%3].GetComponent<SpawnObject>().index = i;
        }
    }

    public void Switch()
    {
        startIndex = ((startIndex + buttonObjects.Count) % 6);
        endIndex = ((endIndex + buttonObjects.Count) % 6);
        SetUpButons();
        Debug.Log(startIndex + " " + endIndex);
    }
}
