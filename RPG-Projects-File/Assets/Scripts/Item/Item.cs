using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    new public string itemName = "New İtem";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    
    public virtual void Use()
    {
        //Use Item
        Debug.Log("Using Item : " + itemName);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
