using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float moveSpeed;
    public bool moveRight;

    // Update is called once per frame
    void Update()
    {
        if(moveRight){
            transform.Translate(2*Time.deltaTime*moveSpeed, 0, 0);
            transform.localScale = new Vector2(-2,2);
        }else {
            transform.Translate(-2*Time.deltaTime*moveSpeed, 0, 0);
            transform.localScale = new Vector2(2,2);
        }
    }

    void OnTriggerEnter2D(Collider2D trig){
        if(trig.gameObject.CompareTag("Turn")){
            if(moveRight){
            moveRight = false;
        }else{
            moveRight = true;
        }
        }
    }
}
