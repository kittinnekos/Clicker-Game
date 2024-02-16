using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static GameData;

public class ScoreCountStop : MonoBehaviour
{
    void Update()
    {
        if(Score <= COUNT_STOP_SCORE) return;
        Score = COUNT_STOP_SCORE;
    }
}
