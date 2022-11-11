using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private float bulletBound = 4.5f; //弾の上限距離
    public AudioClip se;
    // Start is called before the first frame update
    void Start()
    {
        
    }

     private void OnTriggerEnter2D(Collider2D col)
    {
        // 敵だったら
        if (col.gameObject.tag == "Enemy")
        {
            AudioSource.PlayClipAtPoint(se, new Vector3(0.0f, 0.0f, -10.0f));//new Vector3(0.0f, 0.0f, -10.0f)　（メインカメラの位置） -> transform.positionだと爆発した位置で音が鳴るため小さくなる
            // ぶつかった相手を破壊
            Destroy(col.gameObject);
 
            // 弾を破壊
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0.08f, 0);

        if (transform.position.y > bulletBound) //弾が上限に達したら弾を消去
        {
            Destroy(gameObject);
        }
    }


}
