using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public Rigidbody2D fireball;
    public GameObject self;
    public float fireSpeed;

    void Start()
    {
        transform.Rotate(0, 0, 90);
    }
    
    void Update()
    {
        fireball.velocity = transform.up * -fireSpeed;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(self.gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "DetectZone"){
            Destroy(self.gameObject);
        }    
    }
}
