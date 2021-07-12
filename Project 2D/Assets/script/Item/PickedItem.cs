using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickedItem : MonoBehaviour
{
    public showTreassure showTreassure;
    public HookRope hook;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "player"){
            gameObject.SetActive(false);
            showTreassure.isShow = true;
            hook.gotRope = true;
        }
    }
}
