using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showTreassure : MonoBehaviour
{
    public GameObject item;
    public Animator anim;
    public bool isShow;
    private void Start()
    {
        isShow = false;
    }
    void Update()
    {
        if(anim.GetBool("isOpen") && !isShow){
            item.SetActive(true);
        }
        else{
            item.SetActive(false);
        }
    }
}
