using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using static GameData;
using static GameData.TapStatus;

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
            case var istap when istap[(int)start] == true:
            SceneManager.LoadScene("InGame");
            istap[(int)start] = false;
            break;

            case var istap when istap[(int)dragon] == true:
            break;

            case var istap when istap[(int)selectButtonRight] == true:
            break;

            case var istap when istap[(int)selectButtonLeft] == true:
            break;

            case var istap when istap[(int)buyButtonUp] == true:
            break;

            case var istap when istap[(int)buyButtonCenter] == true:
            break;

            case var istap when istap[(int)buyButtonDown] == true:
            break;

            default:
            break;
        }
    }
}
