
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb, enermy, fireballObject;
    public GameObject isGround;
    public Transform FireballSpawnPoint;
    public UI_Player ui;
    public float walkspeed, jumpspeed, jumplimit, manaUsed, mana;
    public LayerMask AirGroundLayer, GroundLayer;
    public bool onPlatform;
    public Animator anim;
    float honmove, jumpcount, moveAxis;
    bool isJumping = false, groundCheck, fliping, isAttack, onGround, isRespawn;

    private void Start()
    {
        fliping = false;
        isAttack = true;
    }
    void Update()
    {   
        mana = ui.ManaPool;
        isRespawn = ui.isRespawn;
        onGround = anim.GetBool("isGround");
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        anim.SetFloat("RunSpeed", honmove*rb.velocity.x);
        honAxisMove();
        jumpAxisMove();
        attack();
        checkSide();
        CheckGround();
        RaycastHit2D PlatformCheck = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, AirGroundLayer);
        if(PlatformCheck.collider != null){
            onPlatform = true;
        }
        else if(PlatformCheck.collider == null){
            onPlatform = false;
        }
        ui.ManaPool = mana;
    }
    void honAxisMove(){
        honmove = Input.GetAxis("Horizontal");
        if(honmove > 0 && !isJumping){
            rb.velocity = new Vector2(walkspeed, rb.velocity.y);
        }
        else if(honmove < 0 && !isJumping){
            rb.velocity = new Vector2(-walkspeed, rb.velocity.y);
        }
        else{
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }    
    void jumpAxisMove(){
        if(Input.GetKeyDown(KeyCode.Space) && jumpcount < jumplimit){
            rb.velocity = new Vector2(rb.velocity.x, jumpspeed);
            isJumping = true;
            jumpcount++;
            anim.SetBool("isFlying", true);
            anim.SetBool("isGround", false);
        }
        if(isJumping || Mathf.Abs(rb.velocity.y) >= 2){
            anim.SetBool("isFlying", true);
            anim.SetBool("isGround", false);
            rb.velocity = new Vector2(honmove*walkspeed, rb.velocity.y);
        }
    }
    void attack(){
        if(Input.GetKeyDown(KeyCode.Mouse0) && onGround && mana >= manaUsed){
            anim.SetBool("isAttacking", true);
            if(isAttack){
                Instantiate(fireballObject, FireballSpawnPoint.transform.position, FireballSpawnPoint.transform.rotation);
                mana -= manaUsed;
            }
            isAttack = false;
        }
        else if(Input.GetKeyUp(KeyCode.Mouse0)){
            anim.SetBool("isAttacking", false);
            isAttack = true;
        }
        else{
            anim.SetBool("isAttacking", false);
        }
    }
    void checkSide(){
        if(fliping && rb.velocity.x > 0){
            fliping = !fliping;
            transform.Rotate(new Vector3(0,180,0));
        }
        else if(!fliping && rb.velocity.x < 0){
            fliping = !fliping;
            transform.Rotate(new Vector3(0,180,0));
        }
    }
    void CheckGround(){
        RaycastHit2D groundCheck = Physics2D.Raycast(transform.position, Vector2.down, 1f, GroundLayer);
        RaycastHit2D AirGroundCheck = Physics2D.Raycast(transform.position, Vector2.down, 1f, AirGroundLayer); 
        if(groundCheck.collider != null || AirGroundCheck.collider != null){
            jumpcount = 0;  
            isJumping = false;
            anim.SetBool("isFlying", false);
            anim.SetBool("isGround", true);
        }
        else if(groundCheck.collider == null && AirGroundCheck.collider == null){
            isJumping = true;
            anim.SetBool("isFlying", true);
            anim.SetBool("isGround", false);
        }
    }
    void respawn(){

    }
    // void OnCollisionEnter2D(Collision2D other)
    // {
    //     if(other.transform.tag == "ground" || other.transform.tag == "AirGround"){
    //         jumpcount = 0;  
    //         isJumping = false;
    //         anim.SetBool("isFlying", false);
    //         anim.SetBool("isGround", true);
    //     }
    //     if(other.transform.tag == null){
    //         isJumping = true;
    //         anim.SetBool("isFlying", true);
    //         anim.SetBool("isGround", false);
    //     }
    // }
}
