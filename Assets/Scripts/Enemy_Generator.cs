using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Generator : MonoBehaviour
{

    // 敵のプレハブ
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 敵をランダムに生成
        if(Random.Range(0, 500) == 1)
        {
            Vector3 pos = new Vector3(Random.Range(-2.8f, 2.8f), 5.5f, 0);  // 画面上方に生成
            Instantiate(enemyPrefab, pos, Quaternion.identity);
        }   
    }
}
