using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private float bulletBound = 4.5f; //�e�̋������������ϐ�

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0.08f, 0);

        if (transform.position.y > bulletBound) //����𒴂����e������
        {
            Destroy(gameObject);
        }
    }


}
