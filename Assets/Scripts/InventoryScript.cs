using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    static public int money = 0;
    //static bool menuActivated;

    //public GameObject InventoryMenu;
    //Creates a dictionary called Inventory
    static public Dictionary<string, int> Inventory = new Dictionary<string, int>()
    {

    };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //When you press e it prints out what you have in your inventory
        if (Input.GetKeyDown("e"))
        {

            foreach (KeyValuePair<string, int> pair in Inventory) 
            {
                Debug.Log($"You currently have {pair.Value} {pair.Key} in your inventory");
            }
            Debug.Log($"You have {money}$ in your purse");
        } 
        //if (Input.GetKeyDown("e") && menuActivated)
        //{
        //    InventoryMenu.SetActive(false);
        //}
        //else if (Input.GetKeyDown("e") && !menuActivated)
        //{
        //    InventoryMenu.SetActive(true);
        //}
    }
}
