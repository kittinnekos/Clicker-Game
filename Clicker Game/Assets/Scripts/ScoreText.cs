using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    Text scoreText; 

    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    void Update()
    {
        OverwriteText();
    }

    void OverwriteText()
    {
        scoreText.text = "Score:" + GameData.Score.ToString();
    }
}
