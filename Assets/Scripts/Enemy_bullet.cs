using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_bullet : MonoBehaviour
{
    private float bulletBound = -4.5f; //弾の上限距離
    // Start is called before the first frame update
    void Start()
    {
        
    }






     private void OnTriggerEnter2D(Collider2D col)
    {
        // 自機だったら
         if (col.gameObject.tag == "own_machine")
         {
            // 自機を破壊 *一撃で破壊処理ではなく、hpを減らしていく仕様に変えたい。
           Destroy(col.gameObject);
 
             // 弾を破壊
             Destroy(gameObject);
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
