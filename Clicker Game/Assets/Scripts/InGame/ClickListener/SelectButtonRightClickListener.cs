using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using static GameData;
using static GameData.TapStatus;

public class SelectButtonRightClickListener : MonoBehaviour
{
    void Start()
    {
        // Buttonコンポーネントがアタッチされているか確認
        Button button = GetComponent<Button>();
        if (button != null)
        {
            // ボタンがクリックされたときに呼び出されるメソッドを設定
            button.onClick.AddListener(OnButtonClick);
        }
        else
        {
            Debug.LogError("Button component not found on the GameObject.");
        }
    }

    void OnButtonClick()
    {
        // MAX_BUY_BUTTONSが要素数の最大値のため-1している
        if(currentBuyButtons >= MAX_SHIFT_BUY_BUTTONS -1) return;
        isTap[(int)selectButtonRight] = true;
    }
}
