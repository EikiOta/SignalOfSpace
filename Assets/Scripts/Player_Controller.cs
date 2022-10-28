using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    float bulletCooldown = 0;

    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        bulletCooldown += Time.deltaTime; //時間をためていく

        if(Input.GetKey(KeyCode.RightArrow)){
            transform.Translate(0.01f, 0, 0);
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Translate(-0.01f, 0, 0);
        }
        if(Input.GetKey(KeyCode.UpArrow)){
            transform.Translate(0, 0.01f, 0);
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            transform.Translate(0, -0.01f, 0);
        }
        if(Input.GetKey(KeyCode.Z) && bulletCooldown > 0.2f){
            bulletCooldown = 0;
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
