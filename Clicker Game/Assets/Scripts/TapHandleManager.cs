using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using static GameData;
using static GameData.TapStatus;
using static BuyManager;

public class TapHandleManager : MonoBehaviour
{
    void Update()
    {
        TapStatusHandler();
    }

    void TapStatusHandler()
    {
        switch(isTap)
        {
            // スタートボタンを押したらインゲームにシーン遷移する
            case var istap when istap[(int)start] == true:
            SceneManager.LoadScene("InGame");
            isTap[(int)start] = false;
            break;

            // ドラゴンかボスを押したらスコアを加算する
            case var istap when istap[(int)dragon] == true:
            Score += AddTapScore;
            isTap[(int)dragon] = false;
            break;

            case var istap when istap[(int)boss] == true:
            Score += AddTapScore;
            isTap[(int)boss] = false;
            break;

            // TODO 敵画像を押したらタップで増えるスコア×２の値スコアに加算する
            case var istap when istap[(int)enemy] == true:
            Score += AddTapScore * 2;
            isTap[(int)enemy] = false;
            break;

            // 右矢印か左矢印を押すと購入ボタンを切り替える
            case var istap when istap[(int)selectButtonRight] == true:
            currentBuyButtons++;
            isTap[(int)selectButtonRight] = false;
            break;

            case var istap when istap[(int)selectButtonLeft] == true:
            currentBuyButtons--;
            isTap[(int)selectButtonLeft] = false;
            break;

            // 購入ボタン
            case var istap when istap[(int)buyButtonUp] == true:
            TryPurchase((int)buyButtonUp-6); // 0を渡したいため-6している
            isTap[(int)buyButtonUp] = false;
            break;

            case var istap when istap[(int)buyButtonCenter] == true:
            TryPurchase((int)buyButtonCenter-6); // 1を渡したいため-6している
            isTap[(int)buyButtonCenter] = false;
            break;

            case var istap when istap[(int)buyButtonDown] == true:
            TryPurchase((int)buyButtonDown-6); // 2を渡したいため-6している
            isTap[(int)buyButtonDown] = false;
            break;

            default:
            break;
        }
    }
}
