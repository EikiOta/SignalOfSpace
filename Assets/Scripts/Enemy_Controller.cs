using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    public float hitPoint; //敵のHPを入れる変数

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject); //敵に接触したオブジェクトを消去

        hitPoint -= 1;

        if (hitPoint <= 0) //HPが0以下ならば消滅
        {
            Destroy(gameObject);
        }
    }
}
