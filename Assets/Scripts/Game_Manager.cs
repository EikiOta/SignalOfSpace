using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; //スコア用のテキストを入れる変数
    public TextMeshProUGUI gameCrearText; //ゲームクリア用のテキストを入れる変数
    public Button restartButton; //リスタートのボタンを入れる変数
    public GameObject titleScreen; //タイトル画面を入れる変数
    private int score; //スコアを入れる変数
    public bool isActive; //ゲームが開始しているかを判定する変数

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "SCORE :" + 0; //スコアを初期化
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

    //ゲームクリア時の処理を記述する関数
    public void GameClear()
    {
        gameCrearText.gameObject.SetActive(true); //ゲームクリアテキストを表示
        restartButton.gameObject.SetActive(true); //リスタートのボタンを表示
    }

    //リスタートの処理を記述する関数
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //シーンを再読み込みする
    }

    //ゲームスタートの処理をする関数
    public void StartGame()
    {
        titleScreen.gameObject.SetActive(false);
        isActive = true;
    }

    //ゲームをやめる処理をする関数
    public void ExitGame()
    {
            UnityEditor.EditorApplication.isPlaying = false; //ゲームプレイ終了(UnityEditor上でプレイ)
            Application.Quit(); //ゲームプレイ終了(ビルドしたゲームをプレイ)
    }
}
