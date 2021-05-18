using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    Equipment[] currentEquipment;
    int countEquipment;
    Inventory inventory;

    public delegate void OnEquipmentChanged(Equipment newItem , Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;
    private void Start()
    {
        inventory = Inventory.instance;
        countEquipment = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[countEquipment];
    }

    public void Equip(Equipment newEquip)
    {
        int slotIndex= (int)newEquip.slotEquipment;
        //Inventory kısmında tıklanan item ile mevcut kullandıgın itemin enum değeri aynı ise
        //tıkladığın item'i kullanmaya başlasın ve kullandığın itemi inventory'e atsın.
        Equipment oldItem = null;
        if(currentEquipment[slotIndex] !=null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.AddItem(oldItem);
        }
        if(onEquipmentChanged!=null)
        {
            onEquipmentChanged.Invoke(newEquip, oldItem);
        }
        currentEquipment[slotIndex] = newEquip;
    }

    public void UnEquip(int slotIndex)
    {
        //Eğer currentEquipment dizisi boş değilse
        if(currentEquipment[slotIndex] != null)
        {
            //Inventory'e atacak olduğun item'i oldItem içerisinde at
            Equipment oldItem = currentEquipment[slotIndex];
            //Inventory'e ekle
            inventory.AddItem(oldItem);
            //currentEquipment dizisinin slotIndex index'i null olsun
            currentEquipment[slotIndex] = null;
            //Ve yapılan equipment değişikliği belirtilsin.
            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
    }

    public void UnEquipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            UnEquip(i);
        }
    }

    private void Update()
    {
        //U tuşuna basarsak tüm itemleri atacak.
        if(Input.GetKeyDown(KeyCode.U))
        {
            UnEquipAll();
        }
    }

}
