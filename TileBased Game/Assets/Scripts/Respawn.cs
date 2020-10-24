using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public int respawn;
    
    void Start()
    {
        
    }

    void Update(){

    }
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Respawn")){
            SceneManager.LoadScene(respawn);
        }
        if(other.gameObject.CompareTag("Enemy")){
            SceneManager.LoadScene(respawn);
        }
    }
}
