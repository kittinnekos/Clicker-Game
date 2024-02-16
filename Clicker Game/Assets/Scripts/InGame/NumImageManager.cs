using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using static GameData;

public class NumImageManager : MonoBehaviour
{
    private int latestScore = Score;
    private GameObject[] digitObject = new GameObject[MAX_SCORE_DIGIT];

    public Sprite[] NumSprites;
    public GameObject digitPrefab;

    void Start()
    {
        UpdateNumberDisplay();
    }

    void Update()
    {
        if(latestScore != Score)
        {
            Debug.Log("a");
            UpdateNumberDisplay();
        }
    }

    void UpdateNumberDisplay()
    {
        DestroyDigitObject();
        latestScore = Score;
        string numberString = Score.ToString();
        if(MAX_SCORE_DIGIT < numberString.Length)
        {
            ScoreCountStopDisplay();
            return;
        }

        // 桁数に応じて数字を表示させる
        for (int i = 0; i < numberString.Length; i++)
        {
            digitObject[i] = Instantiate(digitPrefab, transform);

            // 桁数に応じて数字の位置をずらす
            Vector3 NumberPos = new Vector3
            (transform.position.x * -1 + (float)i / 3, 
            transform.position.y,
            transform.position.z);

            digitObject[i].transform.position = NumberPos;

            Image digitImage = digitObject[i].GetComponent<Image>();

            // 各桁ごとに画像を切り替え
            int digitValue = int.Parse(numberString[i].ToString());

            digitImage.sprite = NumSprites[digitValue];
        }
    }

    void DestroyDigitObject()
    {
        for(int i = 0;i < MAX_SCORE_DIGIT;i++)
        {
            if(digitObject[i] != null)
            {
                Destroy(digitObject[i]);
            }
        }
    }

    void ScoreCountStopDisplay()
    {
        for(int i = 0; i < MAX_SCORE_DIGIT;i++)
        {
            digitObject[i] = Instantiate(digitPrefab, transform);
            // 桁数に応じて数字の位置をずらす
            Vector3 NumberPos = new Vector3
            (transform.position.x * -1 + (float)i / 3, 
            transform.position.y,
            transform.position.z);

            digitObject[i].transform.position = NumberPos;

            Image digitImage = digitObject[i].GetComponent<Image>();

            digitImage.sprite = NumSprites[9];
        }
    }
}
