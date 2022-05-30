using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "ScriptableObjects/Items")]
public class Item : ScriptableObject
{
    [SerializeField]
    string name;
    [SerializeField]
    GameObject model;
    [SerializeField]
    Image icon;


    int quantity;

    public UnityAction<int> quantityChanged; // Sends current amount to listeners

    public void ModifyQuantity(int amount)
    {
        quantity += amount;

        if (amount < 0) 
        {
            amount = 0;
        }

        quantityChanged.Invoke(quantity);
    }

    public bool Purchase(int amount)  // Called when using the shop system.
    {
        if (quantity < amount)
            return false;
        ModifyQuantity(-amount);
        return true;
    }


}