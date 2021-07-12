using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEveryThing : MonoBehaviour
{
    public LineRenderer line;
    public DistanceJoint2D distance;
    public Camera cam;
    public PlayerMove playerMove;
    public LayerMask AirGroundLayer;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        line.enabled = false;
        distance.enabled = false;    
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D Check = Physics2D.Raycast(mousePos, Vector2.positiveInfinity);
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            distance.connectedAnchor = mousePos;
            line.SetPosition(0, mousePos);
            line.SetPosition(1, transform.position);
            playerMove.enabled = false;
            if(Check.collider != null){
                distance.enabled = true;
                line.enabled = true;
                anim.SetBool("isRoping", true);
            }
            else if(Check.collider == null){
                playerMove.enabled = true;
                distance.enabled = false;
                line.enabled = false;
                anim.SetBool("isRoping", false);
            }
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift)){
            playerMove.enabled = true;
            distance.enabled = false;
            line.enabled = false;
            anim.SetBool("isRoping", false);
        }
        if(distance.enabled){
            line.SetPosition(1, transform.position);
        }     
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag == "ground"){
            line.enabled = false;  
            distance.enabled = false;
            anim.SetBool("isRoping", false);
            anim.SetBool("isFlying", false);
        }
    }
}
