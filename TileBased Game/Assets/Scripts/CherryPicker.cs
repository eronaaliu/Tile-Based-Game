using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CherryPicker : MonoBehaviour
{
    private float cherryNumber = 0;
    public TextMeshProUGUI textCherry;
    public GameObject player;

    void OnCollisionEnter2D(Collision2D other){
    
    if(other.gameObject.CompareTag("Cherry")){
        cherryNumber++; 
        textCherry.text = cherryNumber.ToString();
        Destroy(other.gameObject);
      }
    }
}
