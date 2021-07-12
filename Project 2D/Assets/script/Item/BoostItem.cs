using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostItem : MonoBehaviour
{
    public UI_Player ui;
    public bool isRespawn;
    private void Start() {
        isRespawn = false;
    }
    private void Update()
    {
        print(isRespawn);
        isRespawn = ui.isRespawn;
        if(isRespawn){
            respawn();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(gameObject.transform.tag == "ManaPotion"){
            if(other.transform.tag == "player"){
                // Destroy(gameObject);
                gameObject.SetActive(false);
                ui.plusMana = true;
            }
        }
        else if(gameObject.transform.tag == "HPPPotion"){
            if(other.transform.tag == "player"){
                ui.plusHP = true;
                // Destroy(gameObject);
                gameObject.SetActive(false);
            }
        }
    }
    void respawn(){
        print("do in respawn function");
        gameObject.SetActive(true);
        isRespawn = false;
    }
}
