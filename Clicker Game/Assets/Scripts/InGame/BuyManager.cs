using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static GameData;

public class BuyManager : MonoBehaviour
{
    // TODO 購入履歴を元に必要なスコアを出し、持っているスコアと比べて購入するしないを決める

    // このメソッドを呼び出すことで購入処理が行われます
    public static void TryPurchase(int BuyButtons)
    {
        // 成長ボタンが購入上限になった時は購入履歴をリセットして次のステージに切り替わるようにする
        // MAX_PRICE_COUNTは値段を上げる最大回数のため-1している
        if(currentBuyButtons == 0 && BuyButtons == 0 && BuyStack[currentBuyButtons, BuyButtons] == MAX_PRICE_COUNT-1)
        {
            ClearBuyStack(currentBuyButtons, BuyButtons);
            ChangeStageFlag = true;
        }

        // 今の購入ボタンの押されたボタンが値段を上げる最大回数-1より押されたときは買えないようにする
        if(BuyStack[currentBuyButtons, BuyButtons] > MAX_PRICE_COUNT-1)
        {
            Debug.Log("kaenai");
            return;
        }

        int requiredScore = CalculateRequiredScore(BuyButtons);

        if (Score >= requiredScore)
        {
            // 購入可能な場合の処理
            PerformPurchase(BuyButtons);
        }
        else
        {
            // 購入不可の場合の処理
            Debug.Log("Insufficient score to make a purchase.");
        }
    }

    // 購入履歴を元に必要なスコアを計算
    private static int CalculateRequiredScore(int BuyButtons)
    {
        int totalRequiredScore = 0;

        totalRequiredScore += price[BuyStack[currentBuyButtons, BuyButtons]];

        return totalRequiredScore;
    }

    // 購入処理の実装
    private static void PerformPurchase(int BuyButtons)
    {
        Score -= CalculateRequiredScore(BuyButtons);
        BuyStack[currentBuyButtons, BuyButtons]++;
        Debug.Log("Purchase successful. Remaining score: " + Score);
    }

    private static void ClearBuyStack(int i, int j)
    {
        BuyStack[i, j] = 0;
    }
}
