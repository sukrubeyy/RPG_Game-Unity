using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Equipment" , menuName ="Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot slotEquipment;
    public int ArmorModifier;
    public int DamageModifier;
    public SkinnedMeshRenderer mesh;
    public override void Use()
    {
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
        base.Use();
    }
}

public enum EquipmentSlot
{
    Head,Chest,Legs,Weapon,Shield,Feet
}