using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : CharackterAnimator
{
    public WeaponAnimations[] weaponAnimations;
    Dictionary<Equipment, AnimationClip[]> weaponAnimationDictionary;
    protected override void Start()
    {
        base.Start();
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
        weaponAnimationDictionary = new Dictionary<Equipment, AnimationClip[]>();
        foreach (WeaponAnimations item in weaponAnimations)
        {
            weaponAnimationDictionary.Add(item.weapon, item.clips);
        }
    }

    void OnEquipmentChanged(Equipment newEqu, Equipment oldEqu)
    {
        if (newEqu != null && newEqu.slotEquipment == EquipmentSlot.Weapon)
        {
            animator.SetLayerWeight(1, 1);
            if(weaponAnimationDictionary.ContainsKey(newEqu))
            {
                currentAnimationAttackSet = weaponAnimationDictionary[newEqu];
            }
        }
        else if (newEqu == null && oldEqu != null && oldEqu.slotEquipment == EquipmentSlot.Weapon)
        {
            animator.SetLayerWeight(1, 0);
            currentAnimationAttackSet = defaultAnimationSet;
        }

        if (newEqu != null && newEqu.slotEquipment == EquipmentSlot.Shield)
        {
            animator.SetLayerWeight(2, 1);
        }
        else if (newEqu == null && oldEqu != null && oldEqu.slotEquipment == EquipmentSlot.Shield)
        {
            animator.SetLayerWeight(2, 0);
        }
    }

    [System.Serializable]
    public struct WeaponAnimations
        {
        public Equipment weapon;
        public AnimationClip[] clips;
        }
}
