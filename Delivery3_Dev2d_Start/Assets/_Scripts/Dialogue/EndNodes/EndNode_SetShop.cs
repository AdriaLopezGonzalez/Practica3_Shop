using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SetShop", menuName = "Dialogue/EndNodes/SetShop", order = 0)]
public class EndNode_SetShop : EndNode
{
    public static Action ShowInventories;
    public static Action<ShopFeatures> SetShopConditions;
    public ShopFeatures Features;

    public override void Finish(GameObject talker)
    {
        base.Finish(talker);
        ShowInventories?.Invoke();
        SetShopConditions?.Invoke(Features);
    }
}

[System.Serializable]
public class ShopFeatures
{
    public bool toBuy;
    public ProductType whatToSell;
}

public enum ProductType
{
    Weapons,
    Potions,
    Food
}
