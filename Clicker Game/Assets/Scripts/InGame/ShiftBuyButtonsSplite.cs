using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using static GameData;

public class ShiftBuyButtonsSplite : MonoBehaviour
{
    public Sprite[] BuyButtonsUp = new Sprite[MAX_SHIFT_BUY_BUTTONS];
    public Sprite[] BuyButtonsCenter = new Sprite[MAX_SHIFT_BUY_BUTTONS];
    public Sprite[] BuyButtonsDown = new Sprite[MAX_SHIFT_BUY_BUTTONS];

    private Image BuyButtonUpImg;
    private Image BuyButtonSenterImg;
    private Image BuyButtonDownImg;

    void Start()
    {
        // シーン内のBuyButtonsの子オブジェクトからImageコンポーネントを取得する
        Transform BuyButtonUpTF = GameObject.Find("BuyButtons").transform.Find("BuyButtonUp");
        GameObject BuyButtonUpObj = BuyButtonUpTF.gameObject;

        Transform BuyButtonCenterTF = GameObject.Find("BuyButtons").transform.Find("BuyButtonCenter");
        GameObject BuyButtonCenterObj = BuyButtonCenterTF.gameObject;

        Transform BuyButtonDownTF = GameObject.Find("BuyButtons").transform.Find("BuyButtonDown");
        GameObject BuyButtonDownObj = BuyButtonDownTF.gameObject;

        BuyButtonUpImg = BuyButtonUpObj.GetComponent<Image>();
        BuyButtonSenterImg = BuyButtonCenterObj.GetComponent<Image>();
        BuyButtonDownImg = BuyButtonDownObj.GetComponent<Image>();
    }

    void Update()
    {
        ShiftBuyButtons();
    }

    // 画像を今の購入ボタンに合わせて切り替える
    void ShiftBuyButtons()
    {
        BuyButtonUpImg.sprite = BuyButtonsUp[currentBuyButtons];
        BuyButtonSenterImg.sprite = BuyButtonsCenter[currentBuyButtons];
        BuyButtonDownImg.sprite = BuyButtonsDown[currentBuyButtons];
    }
}
