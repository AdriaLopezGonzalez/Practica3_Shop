using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SetShop", menuName = "Dialogue/EndNodes/SetShop", order = 0)]
public class EndNode_SetShop : EndNode
{
    public static Action<EndNode_SetShop> ShowInventories;

    public override void Finish(GameObject talker)
    {
        base.Finish(talker);
        ShowInventories?.Invoke(this);
    }

}
