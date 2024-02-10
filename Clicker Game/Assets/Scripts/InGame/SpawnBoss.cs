using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public GameObject[] BossPrefab = new GameObject[4];

    private GameObject canvas;
    private GameObject BossObject;
    
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        BossObject = Instantiate(BossPrefab[0], BossPrefab[0].transform.position, Quaternion.identity);
        BossObject.transform.SetParent(canvas.transform,false);
    }
}
