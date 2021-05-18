using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
    public GameObject inventoryUI;

    public Transform itemsParent;
    InventorySlot[] slots;
    private void Start()
    {
        inventory = Inventory.instance;
        Debug.Log("Noluyo La");
        inventory.onItemChangedCallBack += updateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }
    private void Update()
    {
        if(Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }
    void updateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if(i<inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot(); 
            }
        }
    }
}
