using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    public float hitPoint; //�G��HP������ϐ�

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
        Destroy(collision.gameObject); //�G�ɐڐG�����I�u�W�F�N�g������

        hitPoint -= 1;

        if (hitPoint <= 0) //HP��0�ȉ��Ȃ�Ώ���
        {
            Destroy(gameObject);
        }
    }
}
