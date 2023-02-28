using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SetShop", menuName = "Dialogue/EndNodes/SetShop", order = 0)]
public class EndNode_SetShop : EndNode
{

    public override void Finish(GameObject talker)
    {
        base.Finish(talker);
        foreach (GameObject inv in FindObjectsOfType<GameObject>(true))
        {
            if(inv.tag == "Inventory")
            {
                inv.SetActive(true);
            }
        }
    }

}
