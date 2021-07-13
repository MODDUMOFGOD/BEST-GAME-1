
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyMove : MonoBehaviour
{
    public GameObject player;
    public UI_Player uiPlayer;
    public Rigidbody2D enermy, movePlayer;
    public Animator anim;
    public float maxDistance, walkspeed,  AttackDamage, attackRange, jumpspeed, forcePlayer, EnermyHealth, fireDamage;
    public LayerMask playerLayer, groundLayer;
    public bool gotRope, isRespawn;
    bool facingRight, platform, isAttacked;
    float maxHp;
    
    private void Start()
    {
        facingRight = true; 
        maxHp = EnermyHealth;
    }
    private void Update()
    {   
        isRespawn = uiPlayer.isRespawn;
        if(isRespawn){
            respawn();
        }
        print(EnermyHealth);
        float hp = uiPlayer.healthBar;
        platform = player.GetComponent<PlayerMove>().onPlatform;
        float distance = UnityEngine.Vector2.Distance(transform.position, player.transform.position);
        RaycastHit2D LattackPoint = Physics2D.Raycast(transform.position, UnityEngine.Vector2.left, attackRange, playerLayer);
        RaycastHit2D RattackPoint = Physics2D.Raycast(transform.position, UnityEngine.Vector2.right, attackRange, playerLayer);
        RaycastHit2D LGroundCheck = Physics2D.Raycast(transform.position, UnityEngine.Vector2.left, 0.5f, groundLayer);
        RaycastHit2D RGroundCheck = Physics2D.Raycast(transform.position, UnityEngine.Vector2.right, 0.5f, groundLayer);
        // print("Distance : " + distance);
        if(distance < maxDistance){
            ChasePlayer();
        }
        else{
            StopChasePlayer();
        }
        if(LattackPoint.collider != null || RattackPoint.collider != null){
            anim.SetBool("isAttacking", true);
            if(!isAttacked){
                hp -= AttackDamage;
                movePlayer.AddForce(transform.right * forcePlayer);
                // movePlayer.velocity = new UnityEngine.Vector2(-forcePlayer, movePlayer.velocity.y);
            }
            uiPlayer.healthBar = hp;
            isAttacked = true;
        }
        else if(LattackPoint.collider == null || RattackPoint.collider == null){
            anim.SetBool("isAttacking", false);
            isAttacked = false;
        }
        if(LGroundCheck.collider != null || RGroundCheck.collider != null){
            enermy.velocity = new UnityEngine.Vector2(enermy.velocity.x, jumpspeed);
        }
        if(platform){
            StopChasePlayer();
        }
        if(EnermyHealth <= 0){
            dead();
        }
    }
    void ChasePlayer(){
        if(transform.position.x > player.transform.position.x){
            enermy.velocity = new UnityEngine.Vector2(-walkspeed, enermy.velocity.y);
            anim.SetFloat("walkspeed", walkspeed);
            if(facingRight){
                facingRight = !facingRight;
                transform.Rotate(0, 180, 0);
            }
        }
        else if(transform.position.x < player.transform.position.x){
            enermy.velocity = new UnityEngine.Vector2(walkspeed, enermy.velocity.y);
            anim.SetFloat("walkspeed", walkspeed);
            if(!facingRight){
                facingRight = !facingRight;
                transform.Rotate(0, 180, 0);
            }
        }
    }
    public void StopChasePlayer(){
        enermy.velocity = new UnityEngine.Vector2(0, enermy.velocity.y);
        anim.SetFloat("walkspeed", 0);
    }
    void dead(){
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag == "fireball"){
            EnermyHealth -= fireDamage;
        }
    }
    void respawn(){
        EnermyHealth = maxHp;
        isRespawn = false;
    }   
}
