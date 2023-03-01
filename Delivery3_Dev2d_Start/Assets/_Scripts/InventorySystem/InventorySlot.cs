using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    public InventoryItem Item;
    public uint Amount;

    public Inventory Inventory => _inventory;
    private Inventory _inventory;

    public InventorySlot(InventoryItem item, Inventory inventory)
    {
        Item = item;
        Amount = 1;
        _inventory = inventory;
    }

    internal void AddOne()
    {
        Amount++;
    }

    internal bool CanHold(InventoryItem item)
    {
        return Amount <100 && Item == item && item.IsStackable;
    }

    internal void RemoveOne()
    {
        Amount--;
    }
}
