using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    void OnEquipmentChanged(Equipment newItem , Equipment oldItem)
    {
        if(newItem!=null)
        {
            armor.AddModifier(newItem.ArmorModifier);
            damage.AddModifier(newItem.DamageModifier);
        }
        if(oldItem!=null)
        {
            armor.RemoveModifier(oldItem.ArmorModifier);
            damage.RemoveModifier(oldItem.DamageModifier);
        }

    }

    public override void Die()
    {
        base.Die();

        PlayerManager.instance.KillPlayer();
    }
}
