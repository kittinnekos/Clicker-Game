using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static GameData;

public class AddScorePeriodicallyHandler : MonoBehaviour
{
    private const float MAX_COUNT = 3.0f;
    private float[,] count = new float[2,3];

    void Update()
    {
        AddScorePeriodically();
    }

    // 購入履歴をもとに購入された分、定期的にスコアを加算する
    public void AddScorePeriodically()
    {
        // ｃは切り替える購入ボタン。ｂは購入ボタンの数。
        for(int c = 0;c < 2;c++)
        {
            for(int b = 0;b < 3;b++)
            {
                // 購入していないときは次のループ
                if(BuyStack[c,b]==0) continue;

                // 成長ボタンの処理
                if(c == 0 && b == 0 && BuyStack[c,b] != 0)
                {
                    // TODO 成長ボタンの処理
                }
                else if(BuyStack[c,b] != 0)
                {
                    count[c,b] += 1 * Time.deltaTime;
                    if(count[c,b] < MAX_COUNT) continue;
                    Score += BASE_ADD_SCORE * BuyStack[c,b];
                    count[c,b] = 0;
                    Debug.Log(c + ","+ b + "BuyStack:" + BuyStack[c,b]);
                }
                
            }
        }
    } 
}
