using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostItem : MonoBehaviour
{
    public UI_Player uI_Player;
    public bool isRespawn2;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(gameObject.transform.tag == "ManaPotion"){
            if(other.transform.tag == "player"){
                // Destroy(gameObject);
                gameObject.SetActive(false);
                uI_Player.plusMana = true;
            }
        }
        else if(gameObject.transform.tag == "HPPPotion"){
            if(other.transform.tag == "player"){
                uI_Player.plusHP = true;
                // Destroy(gameObject);
                gameObject.SetActive(false);
            }
        }
    }
}
