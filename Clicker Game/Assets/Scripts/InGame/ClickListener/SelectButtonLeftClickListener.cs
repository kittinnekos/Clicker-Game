using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using static GameData;
using static GameData.TapStatus;

public class SelectButtonLeftClickListener : MonoBehaviour
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
        if(currentBuyButtons <= 0) return;
        isTap[(int)selectButtonLeft] = true;
    }
}
