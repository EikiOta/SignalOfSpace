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
    //
    public GameObject bullet;
    float bulletCooldown = 0;
    //
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

        if (bulletCooldown > 0.7f)//ここの条件式の数字を増減させることで、弾発射頻度を調整できる。
        {
            bulletCooldown = 0;
            Instantiate(bullet,transform.position, transform.rotation);//弾生成 **敵の弾の発射位置がおかしい. 第二引数"transform.position"をVector3などに変更したが、改善せず.弾を敵の子オブジェクトにする必要ありか？
        }

        bulletCooldown += Time.deltaTime; //時間をためていく
        //aaa
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*以下自機に衝突した場合の処理. タグで分けることで敵同士の衝突による消去を防ぐ.*/
        if(collision.gameObject.tag == "own_bullet"){
        
        Destroy(collision.gameObject); //敵と接触したオブジェクトを消去

        hitPoint -= 1;

        if (hitPoint <= 0) //体力が0以下になったら敵オブジェクトを消去
        {
            Destroy(gameObject);
            gameManager.UpdateScore(score); //スコアテキストのスコアを"score"の値分増やす
        }
    }
    }
}
