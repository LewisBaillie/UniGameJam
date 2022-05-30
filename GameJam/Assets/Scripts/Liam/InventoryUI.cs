using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public ItemIcon listIcon;
    public Transform horizontalBox;

    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        if (inventory == null) { return; }
        inventory.InventoryUpdated += UpdateUI;
        UpdateUI(inventory.items);
    }

    // Update is called once per frame
    void UpdateUI(List<Item> items)
    {
        foreach (Transform child in horizontalBox) { Destroy(child); }
     
        items.ForEach(x => 
        {
            ItemIcon icon = Instantiate(listIcon,horizontalBox);
            icon.Init(x);
        });
    }
}
