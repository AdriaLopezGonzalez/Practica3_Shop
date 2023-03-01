using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SetShop", menuName = "Dialogue/EndNodes/SetShop", order = 0)]
public class EndNode_SetShop : EndNode
{
    public static Action<EndNode_SetShop> ShowInventories;
    public ShopFeatures Features;

    public override void Finish(GameObject talker)
    {
        base.Finish(talker);
        ShowInventories?.Invoke(this);

    }
}

[System.Serializable]
public class ShopFeatures
{
    public bool toBuy;
    public int whatToSell;
    //0 = Weapons
    //1 = Potions
    //2 = Food
}
