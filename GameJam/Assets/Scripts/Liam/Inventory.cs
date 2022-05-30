using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class Inventory : MonoBehaviour
{
    public Item[] startingItems;

    public List<Item> items { get; private set; }

    public UnityAction<List<Item>> InventoryUpdated;

    private void Start()
    {
        items = new List<Item>(startingItems);
    }

    public void AddItem(Item item) 
    {
        items.Add(item);
        InventoryUpdated.Invoke(items);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        InventoryUpdated.Invoke(items);
    }

    public bool Purchase(string name, int quantity) 
    {
        List<Item> temp = items.Where(x => x.itemName == name).ToList();
        return temp[0].Purchase(quantity);
    }
}
