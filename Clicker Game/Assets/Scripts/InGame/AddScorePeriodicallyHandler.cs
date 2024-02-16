using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static GameData;

public class AddScorePeriodicallyHandler : MonoBehaviour
{
    private const float MAX_COUNT = 3.0f;
    private float[,] count = new float[2,3];
    private int CheckGrowthBuyStack = BuyStack[0,0]; // 確認用成長ボタンの購入履歴

    BuyManager buyManager;
    void Start()
    {
        buyManager = gameObject?.GetComponent<BuyManager>();
    }

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
                if(c == 0 && b == 0 && BuyStack[c,b] != 0 && CheckGrowthBuyStack < BuyStack[c,b])
                {
                    AddTapScore++;
                    CheckGrowthBuyStack++;
                }
                // 成長ボタン以外は一定時間でスコアを加算
                else if(c != 0 && BuyStack[c,b] != 0 || b != 0 && BuyStack[c,b] != 0)
                {
                    count[c,b] += 1 * Time.deltaTime;
                    if(count[c,b] < MAX_COUNT) continue;
                    Score += BASE_ADD_SCORE * BuyStack[c,b];
                    count[c,b] = 0;
                }
            }
        }

        // ステージが切り替わったら確認用成長ボタンの購入履歴をリセットする
        if(!ChangeStageFlag) return;
        CheckGrowthBuyStack = 0;
    }
}
