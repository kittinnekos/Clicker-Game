using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDragon : MonoBehaviour
{
    public GameObject[] DragonPrefab = new GameObject[4];

    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        GameObject DragonObject = Instantiate(DragonPrefab[0], DragonPrefab[0].transform.position, Quaternion.identity);
        DragonObject.transform.SetParent(canvas.transform,false);
    }
}
