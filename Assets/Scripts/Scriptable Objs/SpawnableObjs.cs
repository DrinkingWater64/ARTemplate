using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PrefabIconData", menuName = "ScriptableObjects/PrefabIconData", order = 1)]
public class SpawnableObjs : ScriptableObject
{
    public GameObject prefab;
    public Sprite icon;
}
