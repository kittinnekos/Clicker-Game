using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static GameData;

public class SpawnPlanet : MonoBehaviour
{
    private GameObject canvas;
    private GameObject PlanetObject;

    public GameObject[] PlanetPrefab = new GameObject[MAX_STAGE_NUM];

    void Start()
    {
        canvas = GameObject.Find("PlanetCanvas");
        PlanetObject = Instantiate(PlanetPrefab[currentStage], PlanetPrefab[currentStage].transform.position, Quaternion.identity);
        PlanetObject.transform.SetParent(canvas.transform,false);
    }

    void Update()
    {
        Debug.Log(AddTapScore);
        if(!ChangePlanetFlag || currentStage == MAX_STAGE_NUM) return;
        ShiftPlanet();
        ChangePlanetFlag = false;
    }

    void ShiftPlanet()
    {
        Destroy(PlanetObject);
        PlanetObject = Instantiate(PlanetPrefab[currentStage], PlanetPrefab[currentStage].transform.position, Quaternion.identity);
        PlanetObject.transform.SetParent(canvas.transform,false);
    }
}
