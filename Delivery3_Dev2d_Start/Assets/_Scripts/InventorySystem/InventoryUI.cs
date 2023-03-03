using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    Inventory Inventory;
    [SerializeField]
    InventorySlotUI SlotPrefab;

    private List<GameObject> UISlots = new List<GameObject>();

    private void OnEnable()
    {
        Inventory.OnInventoryChanged += UpdateInventory;
        InventoryManager.UpdateInventory += UpdateInventory;
    }
    private void OnDisable()
    {
        Inventory.OnInventoryChanged -= UpdateInventory;
        InventoryManager.UpdateInventory -= UpdateInventory;
    }

    private void UpdateInventory()
    {
        ClearInventory();
        Show(Inventory);
    }

    private void ClearInventory()
    {
        foreach (var item in UISlots)
        {
            Destroy(item);
        }
        UISlots.Clear();
    }

    void Show(Inventory inventory)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            MakeOneEntry(inventory.GetSlot(i));
        }
    }

    private void MakeOneEntry(InventorySlot inventorySlot)
    {
        var slot = Instantiate(SlotPrefab,
            transform.position, Quaternion.identity, transform);
        slot.SetStuff(inventorySlot);
        UISlots.Add(slot.gameObject);
    }
}
