using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_Player : MonoBehaviour
{
    public GameObject player, respawnButton, enermy, item;
    public Transform playerSpawn, enermySpawn;
    public TextMeshProUGUI textMoney;
    public Animator treassureAnim, playerAnim;
    public BoostItem boostItem;
    public float healthBar, ManaPool;
    public Slider slideHP, sliderMana;
    public EnermyMove enermymove;
    public bool plusHP, plusMana, isRespawn;
    // Start is called before the first frame update
    void Start()
    {
        slideHP.maxValue = healthBar;
        slideHP.value = healthBar;
        sliderMana.maxValue = ManaPool;
        sliderMana.value = ManaPool;
        respawnButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        isRespawn = false;
        slideHP.value = healthBar;
        sliderMana.value = ManaPool;
        if(plusHP){
            if(healthBar+50 <= slideHP.maxValue){
                healthBar += 50;
                plusHP = false;
            }
            else{
                healthBar = slideHP.maxValue;
                plusHP = false;
            }
        }
        if(plusMana){
            if(ManaPool+100 <= sliderMana.maxValue){
                    ManaPool += 100;
                    plusMana = false;
            }
            else{
                ManaPool = sliderMana.maxValue;
                plusMana = false;
            }
        }
        Dead();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "treassure"){
            treassureAnim.SetBool("isOpen", true);
        }
    }
    void Dead(){
        bool isDead = false;
        if(healthBar <= 0){
            playerAnim.SetBool("isDead", true);
            Time.timeScale = 0f; 
            isDead = true;
        }
        else{
            playerAnim.SetBool("isDead", false);
            Time.timeScale = 1f;
            isDead = false;
        }
        if(isDead){
            respawnButton.SetActive(true);
        }
    }
    public void respawn(){
        isRespawn = true;
        player.transform.position = playerSpawn.position;
        enermy.transform.position = enermySpawn.position;
        healthBar = 100;
        ManaPool = 200;
        playerAnim.SetBool("isDead", false);
        item.GetComponent<BoostItem>().isRespawn2 = true;
        respawnButton.SetActive(false);
        Time.timeScale = 1f;
    }
}
