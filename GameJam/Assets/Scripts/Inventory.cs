using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class Inventory : MonoBehaviour
{
    public Item[] startingItems;
    List<Item> items;

    public UnityAction<Item> InventoryUpdated;

    private void Start()
    {
        items = new List<Item>(startingItems);
    }

    public void AddItem(Item item) 
    {
        items.Add(item);
        item.quantityChanged += _ => ItemUpdated(item);
    }

    void ItemUpdated(Item item) 
    {
        InventoryUpdated.Invoke(item);
    }

    public bool Purchase(string names, int quantity) 
    {
        List<Item> temp = items.Where(x => x.name == name).ToList();
        return temp[0].Purchase(quantity);
    }
}
