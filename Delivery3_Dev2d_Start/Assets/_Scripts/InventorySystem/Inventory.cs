using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "newInventory", menuName = "Inventory/Inventory", order = 0)]
public class Inventory : ScriptableObject
{
    public int Length => Slots.Count;

    [SerializeField]
    List<InventorySlot> Slots;

    public static Action <ShopFeatures> OnInventoryChanged;

    public void AddItem(InventoryItem item, ShopFeatures currentFeatures)
    {
        if (Slots == null)
            Slots = new List<InventorySlot>();

        var slot = GetSlot(item);
        if (slot != null)
        {
            slot.AddOne();
        }
        else
        {
            slot = new InventorySlot(item, this);
            
            Slots.Add(slot);
        }

        OnInventoryChanged?.Invoke(currentFeatures);

    }

    internal InventorySlot GetSlot(int i)
    {
        return Slots[i];
    }

    private InventorySlot GetSlot(InventoryItem item)
    {
        foreach (var slot in Slots)
        {
            if (slot.CanHold(item))
                return slot;
        }
        return null;
    }

    internal void RemoveItem(InventoryItem item, ShopFeatures currentFeatures)
    {
        var slot = Slots.First(x=> x.Item == item);

        slot.RemoveOne();

        if(slot.Amount<= 0)
        {
            Slots.Remove(slot);
        }

        OnInventoryChanged?.Invoke(currentFeatures);
    }
}
