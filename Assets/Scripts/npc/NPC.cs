using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    void OnMouseEnter()
    {
        CussorManager.instance.SetNpcTalk();
    }

    void OnMouseExit()
    {
        CussorManager.instance.SetNormal();
    }
}
