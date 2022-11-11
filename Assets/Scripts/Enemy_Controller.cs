using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    public float hitPoint; //敵の体力
    public float Speed;     // 速度
    public int score; //獲得できるスコアを入れる変数
    private float pointY;   // プレイヤーに向かってくるY軸の位置
    private float vx;           // X軸の移動量
    private GameObject player;  // プレイヤーオブジェクト取得用
    private Game_Manager gameManager; //スクリプト"Game_Manager"を入れる変数


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<Game_Manager>(); //変数"gameManager"を初期化
        /*aaa*/
        // プレイヤーに向かってくるY軸の位置
        pointY = Random.Range(2.0f, 3.0f);
        // 敵の初期位置とプレイヤーの位置によってX軸の移動方向を決定する（プレイヤーに向かってくるような設定）
        vx = 1.0f;
        player = GameObject.Find("ownMachine");
        if(player.transform.position.x < transform.position.x)
        {
            vx = -vx;
        }
        /*aaa*/
    }

    // Update is called once per frame
    void Update()
    {

        /*aa*/
        // 下に向かって移動する
        transform.position += new Vector3(0, -Speed, 0) * Time.deltaTime;
 
        // 一定の位置になるとプレイヤーに向かって移動する
        if(transform.position.y < pointY)
        {
            transform.position += new Vector3(vx, 0, 0) * Time.deltaTime;
        }
 
        // 画面の下に消えたらオブジェクト消去
         if(transform.position.y < -5.5f)
         {
             Destroy(gameObject);
         }
        /*aa*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject); //敵と接触したオブジェクトを消去

        hitPoint -= 1;

        if (hitPoint <= 0) //体力が0以下になったら敵オブジェクトを消去
        {
            Destroy(gameObject);
            gameManager.UpdateScore(score); //スコアテキストのスコアを"score"の値分増やす
        }
    }
}
