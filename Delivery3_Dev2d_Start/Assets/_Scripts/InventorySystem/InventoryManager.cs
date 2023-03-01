using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] GameObject InventoryShop;
    [SerializeField] GameObject InventoryPlayer;

    private void OnEnable()
    {
        EndNode_SetShop.ShowInventories += ShowInventories;
    }

    private void OnDisable()
    {
        EndNode_SetShop.ShowInventories -= ShowInventories;
    }

    public void ShowInventories(EndNode_SetShop endNode)
    {
        InventoryShop.SetActive(true);
        InventoryPlayer.SetActive(true);
    }

    public void HideInventories()
    {
        InventoryShop.SetActive(false);
        InventoryPlayer.SetActive(false);
    }
}
