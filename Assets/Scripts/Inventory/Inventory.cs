using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<Item> Items = new List<Item>();

    private void Awake()
    {
        instance = this;
    }
    public void AddItem(Item itemToAdd)
    {
        bool itemExist = false;
        foreach (Item item in Items)
        {
            if (item.name == itemToAdd.name)
            {
                item.count += itemToAdd.count;
                itemExist = true;
                break;
            }
        }
        if (!itemExist)
        {
            Items.Add(itemToAdd);
        }
        Debug.Log(itemToAdd.count + " " + itemToAdd.name + " added to inventory");
    }

    public void RemoveItem(Item itemToRemove)
    {
        foreach (var item in Items)
        {
            if (item.name == itemToRemove.name)
            {
                item.count -= itemToRemove.count;
                if(item.count <= 0)
                {
                    Items.Remove(itemToRemove);
                }
                break;
            }
        }
        Debug.Log(itemToRemove.count + " " + itemToRemove.name + " removed from inventroy");
    }
}
