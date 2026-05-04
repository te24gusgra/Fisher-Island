using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Fishing : MonoBehaviour
{
    // Getting the dictionaries
    public FishData fishData;
    public InventoryScript inventoryscript;

    public Transform player;

    GameObject[] tileMapsContainers;
    Tilemap[] tileMaps;


    //Variables
    public string selectedItem;
    public int sellValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    string GetWaterType()
    {
        tileMapsContainers = GameObject.FindGameObjectsWithTag("WaterType");
        tileMaps = new Tilemap[tileMapsContainers.Length];

        for (int i = 0; i < tileMapsContainers.Length; i++)
        {
            tileMaps[i] = tileMapsContainers[i].GetComponent<Tilemap>();
        }

        for (int i = 0; i < tileMapsContainers.Length; i++)
        {
            GameObject tilemapContainer = tileMapsContainers[i];
            Tilemap tilemap = tilemapContainer.GetComponent<Tilemap>();

            Vector3Int cellPosition = tilemap.WorldToCell(player.position);

            if (tilemap.HasTile(cellPosition)) 
            {
                return tilemapContainer.name;
            }
        }

        return "NoWater";
    }

    string GetShopArea()
    {
        tileMapsContainers = GameObject.FindGameObjectsWithTag("ShopArea");
        tileMaps = new Tilemap[tileMapsContainers.Length];

        for (int i = 0; i < tileMapsContainers.Length; i++)
        {
            tileMaps[i] = tileMapsContainers[i].GetComponent<Tilemap>();
        }

        for (int i = 0; i < tileMapsContainers.Length; i++)
        {
            GameObject tilemapContainer = tileMapsContainers[i];
            Tilemap tilemap = tilemapContainer.GetComponent<Tilemap>();

            Vector3Int cellPosition = tilemap.WorldToCell(player.position);

            if (tilemap.HasTile(cellPosition))
            {
                return tilemapContainer.name;
            }
        }

        return "NoShopArea";
    }

    void Fish(string waterType)
    {

        if (waterType == "FreshWater")
        {
            //Goes down to the WeightedRandom function below, changing the dictionary to FreshWater found in the FishData script and sets the water type to fresh water
            selectedItem = WeightedRandom(FishData.FreshWater);
        }
        else if (waterType == "SaltWater")
        {
            //Goes down to the WeightedRandom function below, changing the dictionary to SaltWater found in the FishData script and sets the water type to salt water
            selectedItem = WeightedRandom(FishData.SaltWater);
        }

        //Prints out what type of water you fished in and what you got in the console
        Debug.Log($"You fished in {waterType} and got a {selectedItem}");

        //Tries to create a new object in the inventory with the fish that got fished up 
        try
        {
            InventoryScript.Inventory.Add(selectedItem, 0);
        }
        //If the object already exits it just skips
        catch { }

        //Adds the fish into the inventory
        InventoryScript.Inventory[selectedItem]++;
    }

    void Sell()
    {
        Debug.Log("You sold all your fish");
        foreach (KeyValuePair<string, int> pair in InventoryScript.Inventory)
        {
            sellValue = pair.Value * FishData.SellValues[pair.Key];
            InventoryScript.money += sellValue;
        }
        InventoryScript.Inventory.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        //Starts when the user presses f
        if (Input.GetKeyDown("f"))
        {
            string playerWaterType = GetWaterType();
            string playerShopArea = GetShopArea();
            if (playerWaterType != "NoWater")
            {
                Fish(playerWaterType);
            }
            else if (playerShopArea != "NoShopArea")
            {
                Sell();
            }
            else
            {
                Debug.Log("Du är ju inte ens nära något");
            }
        }
    }
    //Creates a function called WeightedRandom and gives it a dictionary
    public static string WeightedRandom(Dictionary<string, int> WeightedDictionary)
    {
        //Creates an int with the starting value 0
        int TotalWeight = 0;

        //Goes through the given dictionary and sums up the total weight/int number all the objects have
        foreach (KeyValuePair<string, int> pair in WeightedDictionary)
        {
            TotalWeight += pair.Value;
        }

        //Makes a new random that chooses between the number 1 and the total of the chosen dictionary
        int chance = UnityEngine.Random.Range(1, TotalWeight + 1);

        //Creates an int with the value 0
        int counter = 0;

        //The weighted random selection process were it goes through each pair and adds the value to counter like TotalWeight did and then compares the chosen random number with the counter and gets the corresponding object
        foreach (KeyValuePair<string, int> pair in WeightedDictionary)
        {
            counter += pair.Value;
            if (chance <= counter)
            {
                //Sends back the random object from the dictionary into the string selectedItem
                return (pair.Key);
            }
        }

        //If I dont have this then not all code paths return a value
        throw new InvalidOperationException("Random selection failed");
    }
}