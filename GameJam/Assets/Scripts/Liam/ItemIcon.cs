using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemIcon : MonoBehaviour
{
    int currentAmount;
    public Image icon;
    public TextMeshProUGUI text;

    void Init(Item item) 
    {
        icon = item.icon;
        item.quantityChanged += UpdateUI;
    }

    void UpdateUI(int amount) 
    {
        text.text = amount.ToString();
    }
}
