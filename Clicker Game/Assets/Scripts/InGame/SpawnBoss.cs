using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static GameData;

public class SpawnBoss : MonoBehaviour
{
    private GameObject canvas;
    private GameObject BossObject;
    
    public GameObject[] BossPrefab = new GameObject[MAX_STAGE_NUM];

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        BossObject = Instantiate(BossPrefab[currentStage], BossPrefab[currentStage].transform.position, Quaternion.identity);
        BossObject.transform.SetParent(canvas.transform,false);
    }

    void Update()
    {
        if(!ChangeBossFlag || currentStage == MAX_STAGE_NUM) return;
        ShiftBoss();
        ChangeBossFlag = false;
    }

    void ShiftBoss()
    {
        Destroy(BossObject);
        BossObject = Instantiate(BossPrefab[currentStage], BossPrefab[currentStage].transform.position, Quaternion.identity);
        BossObject.transform.SetParent(canvas.transform,false);
    }
    
}
