using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newItem", menuName = "Inventory/Item", order = 0)]
public class InventoryItem : ScriptableObject
{
    public string Name;
    public Sprite ImageUI;
    public bool IsStackable;
    public ProductType Type;
    public int prize;
}
