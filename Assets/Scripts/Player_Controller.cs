using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    float bulletCooldown = 0;
    private float xBound = 2.4f; //xの上限を入れる変数
    private float yBound = 4.5f; //yの上限を入れる変数
    private Game_Manager gameManager; //スクリプト"Game_Manager"を入れる変数

    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<Game_Manager>(); //変数"gameManager"を初期化
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isActive) //ゲームを開始していないときは操作不可
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(0.01f, 0, 0);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-0.01f, 0, 0);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0, 0.01f, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0, -0.01f, 0);
            }
            if (Input.GetKey(KeyCode.Z) && bulletCooldown > 0.2f)
            {
                bulletCooldown = 0;
                Instantiate(bullet, transform.position, transform.rotation);
            }
        }

        bulletCooldown += Time.deltaTime; //時間をためていく

        //右方向の上限を設定
        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, 0);
        }

        //左方向の上限を設定
        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, 0);
        }

        //上方向の上限を設定
        if (transform.position.y > yBound)
        {
            transform.position = new Vector3(transform.position.x, yBound, 0);
        }

        //下方向の上限を設定
        if (transform.position.y < -yBound)
        {
            transform.position = new Vector3(transform.position.x, -yBound, 0);
        }
    }
}
