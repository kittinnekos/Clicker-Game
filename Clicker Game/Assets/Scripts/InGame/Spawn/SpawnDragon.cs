using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static GameData;

public class SpawnDragon : MonoBehaviour
{
    private GameObject canvas;
    private GameObject DragonObject;

    public GameObject[] DragonPrefab = new GameObject[MAX_STAGE_NUM];

    void Start()
    {
        canvas = GameObject.Find("Dragon,BossCanvas");
        DragonObject = Instantiate(DragonPrefab[currentStage], DragonPrefab[currentStage].transform.position, Quaternion.identity);
        DragonObject.transform.SetParent(canvas.transform,false);
    }

    void Update()
    {
        if(!ChangeDragonFlag || currentStage == MAX_STAGE_NUM) return;
        ShiftDragon();
        ChangeDragonFlag = false;
    }

    void ShiftDragon()
    {
        Destroy(DragonObject);
        DragonObject = Instantiate(DragonPrefab[currentStage], DragonPrefab[currentStage].transform.position, Quaternion.identity);
        DragonObject.transform.SetParent(canvas.transform,false);
    }
}
