using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherBoostingItm : MonoBehaviour
{
    public UI_Player uI_Player;
    public GameObject item;
    bool isRespawn;
    private void Update()
    {
        isRespawn = uI_Player.isRespawn;
        if(isRespawn){
            item.SetActive(true);
        }
    }
}
