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
    public Equipment[] defaultItems;
    public delegate void OnEquipmentChanged(Equipment newItem , Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    SkinnedMeshRenderer[] currentMesh;
    public SkinnedMeshRenderer targetMesh;
    private void Start()
    {
        inventory = Inventory.instance;
        countEquipment = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[countEquipment];
        currentMesh = new SkinnedMeshRenderer[countEquipment];
        DefaultItem();
    }

    public void Equip(Equipment newEquip)
    {
        int slotIndex= (int)newEquip.slotEquipment;
       
        //Inventory kısmında tıklanan item ile mevcut kullandıgın itemin enum değeri aynı ise
        //tıkladığın item'i kullanmaya başlasın ve kullandığın itemi inventory'e atsın.
        Equipment oldItem = UnEquip(slotIndex);

        //if(currentEquipment[slotIndex] !=null)
        //{
        //    oldItem = currentEquipment[slotIndex];
        //    inventory.AddItem(oldItem);
        //}

        if (onEquipmentChanged!=null)
        {
            onEquipmentChanged.Invoke(newEquip, oldItem);
        }
        currentEquipment[slotIndex] = newEquip;

        SetEquipmentBlendShapes(newEquip, 100);  

        //Oluşturduğumuz SkinnedMeshRenderer nesnesine -> SkinnedMeshRenderer oluşturup bunun içerisine ise almış olduğumuz 
        //equipment objesinin içerisinde yer alan mesh'i gönderiyoruz.
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newEquip.mesh);
        //newMesh objesini player objemizin child'ı yapıyoruz ki onla beraber hareket etsin.
        newMesh.transform.parent = targetMesh.transform;
        //Kemik sistemlerini eşitliyoruz.
        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;

        currentMesh[slotIndex] = newMesh;
    }

    public void SetEquipmentBlendShapes(Equipment item , int weight)
    {
        foreach (EquipmentMeshRegion blendShape in item.coveredMeshRegion)
        {
            targetMesh.SetBlendShapeWeight((int)blendShape, weight);
        }
    }

    public Equipment UnEquip(int slotIndex)
    {
        //Eğer currentEquipment dizisi boş değilse
        if(currentEquipment[slotIndex] != null)
        {
            if(currentMesh[slotIndex]!=null)
            {
                Destroy(currentMesh[slotIndex].gameObject); 
            }

            //Inventory'e atacak olduğun item'i oldItem içerisinde at
            Equipment oldItem = currentEquipment[slotIndex];
            //Inventory'e ekle
            inventory.AddItem(oldItem);
            //BlendShape Changes
            SetEquipmentBlendShapes(oldItem,0);
            //currentEquipment dizisinin slotIndex index'i null olsun
            currentEquipment[slotIndex] = null;
            //Ve yapılan equipment değişikliği belirtilsin.
            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
            return oldItem;
        }
        return null;
    }

    void DefaultItem()
    {
        foreach (Equipment item in defaultItems)
        {
            Equip(item);
        }
    }
    public void UnEquipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            UnEquip(i);
        }
        DefaultItem();
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
