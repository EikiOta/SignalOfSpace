using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Generator : MonoBehaviour
{
    [SerializeField] int maxNumOfEnemys;//インスペクター側で敵の最大出現数を指定
    int NumOfEnemys = 0;//敵の数のカウンタ
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

        /*enemyの総数がインスペクタで指定したmaxNumOfEnemysを下回っている場合、かつ0~500の間の乱数で1になった場合に敵を出現.
        つまりRandom.Rangeの引数の差を大きくすれば1の出現確率は減り、敵の出現も実行されにくくなる.*/
        if(NumOfEnemys < maxNumOfEnemys && Random.Range(0, 500) == 1)
        {
            /*出現*/
            Vector3 pos = new Vector3(Random.Range(-2.8f, 2.8f), 5.5f, 0);  // 画面上方に生成
            Instantiate(enemyPrefab, pos, Quaternion.identity);
            
            NumOfEnemys++;//カウンタを1増やす
        }else{
            /*全ての敵が出現したため、GameClearの処理を記述*/
        }
    }
}
