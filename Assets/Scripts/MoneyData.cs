using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyData : MonoBehaviour
{
    // Variables
    static public int money = 0;

    [SerializeField]
    private TMP_Text totalMoney;

    // Sells the fish in your inventory
    static public int Sell()
    {
        // Creates a variable with the starting value 0
        int sellValue = 0;

        // Goes through the fish in your inventory and multiply them with the amount of fish you have and the sell value
        foreach (KeyValuePair<string, int> pair in InventoryScript.Inventory)
        {
            sellValue += pair.Value * FishData.SellValues[pair.Key];
        }

        // Clears the inventory
        InventoryScript.Inventory.Clear();

        // stores the information
        money += sellValue;

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
        // Checks how much money you have in total and displays it
        totalMoney.text = $"${money.ToString()}";
    }
}
