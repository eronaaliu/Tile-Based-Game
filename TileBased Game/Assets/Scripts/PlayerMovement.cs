using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public bool isGrounded = false;


    public GameObject player, restartGameText, restartButton;

    void Start()
    {
        restartGameText.SetActive(false);
        restartButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        //MOVE
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        
        //FLIP
        Vector3 characterScale = transform.localScale;
        if(Input.GetAxis("Horizontal") < 0){
            characterScale.x = -4;
        }else if(Input.GetAxis("Horizontal") > 0){
            characterScale.x = 4;
        }
        transform.localScale = characterScale;
        transform.position += movement * Time.deltaTime * moveSpeed;
    }

    void Jump(){
        if(Input.GetButtonDown("Jump") && isGrounded){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Ground")){
            isGrounded = true;
        }
        if(other.gameObject.CompareTag("Platform")){
            isGrounded = true;
            player.transform.parent = other.gameObject.transform;
        }
        if(other.gameObject.CompareTag("Gem")){
            restartGameText.SetActive(true);
            restartButton.SetActive(true);
            Time.timeScale = 0;
        }
       /* if(other.gameObject.tag.Equals("Cherry")){
            Destroy(other.gameObject);
        }*/
    }

    void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.tag.Equals("Platform")){
            isGrounded = true;
            player.transform.parent = null;
       }
    }



}
