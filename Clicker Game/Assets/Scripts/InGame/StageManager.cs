using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using static GameData;

public class StageManager : MonoBehaviour
{
    void Update()
    {
        ChangeStages();
        EndGame();
    }

    void ChangeStages()
    {
        if(!ChangeStageFlag) return;
        currentStage++;
        ChangeStageFlag = false;
        ChangeDragonFlag = true; ChangeBossFlag = true; ChangeEnemyFlag = true; 
    }

    void EndGame()
    {
        if(currentStage == MAX_STAGE_NUM)
        {
            SceneManager.LoadScene("Result");
        }
    }
}
