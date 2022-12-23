using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_bullet : MonoBehaviour
{
    private float bulletBound = -4.5f; //弾の上限距離
    private Game_Manager gameManager; //スクリプト"Game_Manager"を入れる変数
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<Game_Manager>(); //変数"gameManager"を初期化
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // 自機だったら
        if (col.gameObject.tag == "own_machine")
        {
            // 自機を破壊 *一撃で破壊処理ではなく、hpを減らしていく仕様に変えたい。
            col.gameObject.GetComponent<Player_Controller>().playerHitPoint -= 1; //弾が当たると自機のHPが1減る

            // 弾を破壊
            Destroy(gameObject);

            //自機のHPがなくなったら自機を消去し、ゲームオーバーの処理を行う
            if (col.gameObject.GetComponent<Player_Controller>().playerHitPoint <= 0)
            {
                Destroy(col.gameObject);
                gameManager.GameOver();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -0.01f, 0);

        if (transform.position.y < bulletBound) //弾が上限に達したら弾を消去
        {
            Destroy(gameObject);
        }
    }
}
