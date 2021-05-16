using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region
    public static Inventory instance;
 

    private void Awake()
    {
        if(instance!=null)
        {
            Debug.LogWarning("More Than one instance of Inventory found");
            return;
        }
        instance = this;
    }
    #endregion
    public List<Item> items = new List<Item>();
    public int itemCountEnough = 20;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;
    public bool AddItem(Item item)
    {
        if(!item.isDefaultItem)
        {
            if(items.Count>=itemCountEnough)
            {
                Debug.Log("Not Enough  room");
                return false;
            }
            items.Add(item);

            if (onItemChangedCallBack != null)
                onItemChangedCallBack.Invoke();
        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }
}
