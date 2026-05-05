using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyData : MonoBehaviour
{
    static public int money = 0;
    static public int sellValue;

    [SerializeField]
    private TMP_Text totalMoney;

    static public void Sell()
    {
        foreach (KeyValuePair<string, int> pair in InventoryScript.Inventory)
        {
            sellValue = pair.Value * FishData.SellValues[pair.Key];
            money += sellValue;
        }
        InventoryScript.Inventory.Clear();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalMoney.text = $"${money.ToString()}";
    }
}
