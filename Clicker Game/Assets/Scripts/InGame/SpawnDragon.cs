using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDragon : MonoBehaviour
{
    public GameObject[] DragonPrefab = new GameObject[4];

    private GameObject canvas;
    private GameObject DragonObject;

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        DragonObject = Instantiate(DragonPrefab[0], DragonPrefab[0].transform.position, Quaternion.identity);
        DragonObject.transform.SetParent(canvas.transform,false);
    }
}
