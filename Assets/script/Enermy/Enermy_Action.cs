using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy_Action : MonoBehaviour
{
    public Rigidbody2D enermy, player;
    public float jumpspeed,  AttackDamage, attackRange;
    public Animator anim;
    public void Update()
    {
        if(anim.GetBool("isAttacking")){
            EnermyAttack();
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag == "ground"){
            enermy.velocity = new Vector2(enermy.velocity.x, jumpspeed);
        }
        if(other.transform.tag == "player"){
            anim.SetBool("isAttacking", true);
        }
        else{
            anim.SetBool("isAttacking", false);
        }
    }
    void EnermyAttack(){
        RaycastHit2D attackPoint = Physics2D.Raycast(transform.position, Vector2.positiveInfinity, attackRange);
        if(attackPoint.transform.tag == "player"){
            ((UI_Player)gameObject.GetComponent<UI_Player>()).healthBar -= AttackDamage;
        }
    }
}
