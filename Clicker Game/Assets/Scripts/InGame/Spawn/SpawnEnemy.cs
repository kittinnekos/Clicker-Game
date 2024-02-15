using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static GameData;

public class SpawnEnemy : MonoBehaviour
{
    private GameObject canvas;
    private GameObject[] EnemyObject = new GameObject[MAX_SPAWN_ENEMY];
    private GameObject[,] EnemyPrefabs = new GameObject[MAX_STAGE_NUM,ENEMY_NUM];
    private Vector3[] EnemyPosition = new Vector3[MAX_SPAWN_ENEMY]
    {
        new Vector3(-200f,240f,0),// 上一列目のポジション
        new Vector3(-120f,240f,0),
        new Vector3(-40f,240f,0),
        new Vector3(40f,240f,0),
        new Vector3(120f,240f,0),
        new Vector3(200f,240f,0),
        new Vector3(-160f,120f,0),// ここから二列目のポジション
        new Vector3(-80f,120f,0),
        new Vector3(80f,120f,0),
        new Vector3(160f,120f,0)
    };

    public GameObject[] Stage1Enemy = new GameObject[ENEMY_NUM];
    public GameObject[] Stage2Enemy = new GameObject[ENEMY_NUM];
    public GameObject[] Stage3Enemy = new GameObject[ENEMY_NUM];
    public GameObject[] Stage4Enemy = new GameObject[ENEMY_NUM];

    void Start()
    {
        canvas = GameObject.Find("EnemyCanvas");
        // EnemyPrefabsにステージ別の敵プレハブを入れている
        for(int i = 0;i < MAX_STAGE_NUM;i++)
        {
            for(int j = 0;j < ENEMY_NUM;j++)
            {
                EnemyPrefabs[i, j] = GetStageEnemy(i, j);
            }
        }
        StartCoroutine(SpawnEnemys());
    }

    void Update()
    {
        if(ChangeEnemyFlag)
        {
            AllEnemyDestroy();
            ChangeEnemyFlag = false;
        }
    }

    GameObject GetStageEnemy(int stageIndex, int enemyIndex)
    {
        switch (stageIndex)
        {
            case 0:
                return Stage1Enemy[enemyIndex];
            case 1:
                return Stage2Enemy[enemyIndex];
            case 2:
                return Stage3Enemy[enemyIndex];
            case 3:
                return Stage4Enemy[enemyIndex];
            default:
                // stageIndexが範囲外の場合の処理を追加
                return null;
        }
    }

    IEnumerator SpawnEnemys()
    {
        while(true)
        {
            for(int i = 0;i < MAX_SPAWN_ENEMY;i++)
            {
                if(EnemyObject[i] != null) continue;
                yield return new WaitForSeconds(2.0f);
                int SpawnEnemyNum = Random.Range(0, 2);
                EnemyObject[i] = Instantiate(EnemyPrefabs[currentStage,SpawnEnemyNum], EnemyPosition[i], Quaternion.identity);
                EnemyObject[i].transform.SetParent(canvas.transform,false);
            }
            yield return null;
        }
    }

    void AllEnemyDestroy()
    {
        for(int i = 0;i < MAX_SPAWN_ENEMY;i++)
        {
            if(EnemyObject[i] != null)
            {
                Destroy(EnemyObject[i]);
            }
        }
    }
}
