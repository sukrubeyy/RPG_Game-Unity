using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item item;
    public override void Interact()
    {
        pickUpItem();
    }

     void pickUpItem()
    {
       bool isItWasPickUp=  Inventory.instance.AddItem(item);
        //Inventory'e ekle
        if(isItWasPickUp)
             Destroy(gameObject);
    }
}
