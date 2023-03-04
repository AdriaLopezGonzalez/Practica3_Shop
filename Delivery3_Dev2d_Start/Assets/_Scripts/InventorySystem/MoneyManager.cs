using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class MoneyManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI ShopMoney;
    [SerializeField]
    TextMeshProUGUI PlayerMoney;

    public bool CheckTransaction(InventoryItem item, ShopFeatures currentFeatures)
    {
        int possiblePlayerMoney;
        int possibleShopMoney;
        if (currentFeatures.toBuy)
        {
            possiblePlayerMoney = (Int32.Parse(PlayerMoney.text) - item.prize);
            possibleShopMoney = (Int32.Parse(ShopMoney.text) + item.prize);
        }
        else
        {
            possiblePlayerMoney = (Int32.Parse(PlayerMoney.text) + item.prize);
            possibleShopMoney = (Int32.Parse(ShopMoney.text) - item.prize);
        }

        return (possiblePlayerMoney > 0) && (possibleShopMoney > 0);
    }

    public void MoneyExchange (InventoryItem item, ShopFeatures currentFeatures)
    {
        if (currentFeatures.toBuy)
        {
            PlayerMoney.text = (Int32.Parse(PlayerMoney.text) - item.prize).ToString();
            ShopMoney.text = (Int32.Parse(ShopMoney.text) + item.prize).ToString();
        }
        else
        {
            PlayerMoney.text = (Int32.Parse(PlayerMoney.text) + item.prize).ToString();
            ShopMoney.text = (Int32.Parse(ShopMoney.text) - item.prize).ToString();
        }
    }
}
