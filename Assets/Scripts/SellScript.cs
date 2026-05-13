using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class SellScript : MonoBehaviour, IPointerClickHandler
{
    public float timer;

    [SerializeField]
    public TMP_Text sellActionText;

    public void OnPointerClick(PointerEventData eventData)
    {
        // Gets the total money you sold your fish for
        float sellValue = Sell();

        // Checks if you acually sold any fish or not
        if (sellValue > 0)
        {
            // Announces that you sold your fish
            sellActionText.text = $"You just sold all your fish and got ${sellValue}";
        }

        timer = Time.time + 3;
    }

    // Sells the fish in your inventory
    static public float Sell()
    {
        // Creates a variable with the starting value 0
        float sellValue = 0;

        // Goes through the fish in your inventory and multiply them with the amount of fish you have and the sell value
        foreach (KeyValuePair<string, int> pair in InventoryScript.Inventory)
        {
            sellValue += pair.Value * FishData.SellValues[pair.Key] * ShopScript.moneyMultiplier;
        }

        // Clears the inventory
        InventoryScript.Inventory.Clear();

        // stores the information
        ShopScript.money += sellValue;

        // Returns the amount you sold for
        return sellValue;
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timer) 
        {
            sellActionText.text = null;
        }
    }
}
