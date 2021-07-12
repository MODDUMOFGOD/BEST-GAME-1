using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTrigger : MonoBehaviour
{
    public GameObject player;
    void OnTriggerEnter2D(Collider2D coin)
    {
        if(coin.transform.tag == "player"){
            Destroy(coin.gameObject);
        }        
    }
}
