using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game_Manager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; //スコア用のテキストを入れる変数
    private int score; //スコアを入れる変数

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //スコアを更新する関数
    public void UpdateScore(int addScore)
    {
        score += addScore; //スコアを"addScore"の値分増やす
        scoreText.text = "SCORE :" + score; //スコアテキストを更新
    }
}
