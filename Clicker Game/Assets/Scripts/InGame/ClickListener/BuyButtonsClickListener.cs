using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using static GameData;
using static GameData.TapStatus;

public class BuyButtonsClickListener : MonoBehaviour
{
    // TODO Up,Center,Downの購入を管理するスクリプトを作成
    // 購入ボタンが押されたときに今の購入ボタンに合わせてスコア消費で購入する。
    // 購入するたびにスコア消費が上がる
    void Start()
    {
        // シーン内のBuyButtonsの子オブジェクトからButtonコンポーネントを取得する
        Transform BuyButtonUpTF = GameObject.Find("BuyButtons").transform.Find("BuyButtonUp");
        GameObject BuyButtonUpObj = BuyButtonUpTF.gameObject;

        Transform BuyButtonCenterTF = GameObject.Find("BuyButtons").transform.Find("BuyButtonCenter");
        GameObject BuyButtonCenterObj = BuyButtonCenterTF.gameObject;

        Transform BuyButtonDownTF = GameObject.Find("BuyButtons").transform.Find("BuyButtonDown");
        GameObject BuyButtonDownObj = BuyButtonDownTF.gameObject;

        Button buttonUp = BuyButtonUpObj.GetComponent<Button>();
        Button buttonCenter = BuyButtonCenterObj.GetComponent<Button>();
        Button buttonDown = BuyButtonDownObj.GetComponent<Button>();

        // ボタンがクリックされたときに呼び出されるメソッドを設定
        buttonUp?.onClick.AddListener(OnButtonUpClick);
        buttonCenter?.onClick.AddListener(OnButtonCenterClick);
        buttonDown?.onClick.AddListener(OnButtonDownClick);
    }

    void OnButtonUpClick()
    {
        isTap[(int)buyButtonUp] = true;
    }

    void OnButtonCenterClick()
    {
        isTap[(int)buyButtonCenter] = true;
    }

    void OnButtonDownClick()
    {
        isTap[(int)buyButtonDown] = true;
    }
}
