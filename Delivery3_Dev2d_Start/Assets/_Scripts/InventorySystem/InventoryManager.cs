using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] GameObject InventoryShop;
    [SerializeField] GameObject InventoryPlayer;

    public static Action<ShopFeatures> UpdateInventory;

    public ShopFeatures CurrentFeatures { get; private set; }

    private void OnEnable()
    {
        EndNode_SetShop.ShowInventories += ShowInventories;
        EndNode_SetShop.SetShopConditions += SetShopConditions;
    }

    private void OnDisable()
    {
        EndNode_SetShop.ShowInventories -= ShowInventories;
        EndNode_SetShop.SetShopConditions -= SetShopConditions;
    }

    public void ShowInventories()
    {
        InventoryShop.SetActive(true);
        InventoryPlayer.SetActive(true);
        UpdateInventory?.Invoke(CurrentFeatures);
    }

    public void HideInventories()
    {
        InventoryShop.SetActive(false);
        InventoryPlayer.SetActive(false);
    }

    public void SetShopConditions(ShopFeatures features)
    {
        CurrentFeatures = features;
    }
    
}
