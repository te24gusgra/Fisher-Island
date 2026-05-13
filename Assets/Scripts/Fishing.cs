using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.U2D;
using TMPro;
using System.Threading;
using UnityEditor.AssetImporters;
using Unity.Jobs.LowLevel.Unsafe;

public class Fishing : MonoBehaviour
{
    // Variables
    public string[] selectedItem;
    public double nextEvent = 0;
    public bool cooldownActive = false;
    static public float timer;

    // Getting outside information
    public InventoryScript inventoryScript;

    public Transform player;

    [SerializeField]
    public TMP_Text fishActionText;

    [SerializeField]
    public TMP_Text cooldownText;

    // Creating arrays
    GameObject[] tileMapsContainers;
    Tilemap[] tileMaps;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Getting the script
        inventoryScript = GameObject.Find("InventoryCanvas").GetComponent<InventoryScript>();
    }

    // Figuring out if the player is on a tile next to water
    string GetWaterType()
    {
        // Getting the gameobjects with the tag WaterType
        tileMapsContainers = GameObject.FindGameObjectsWithTag("WaterType");

        // Recreates the array with the same length as there are with the tag WaterType
        tileMaps = new Tilemap[tileMapsContainers.Length];

        // Loops through as many times as the array has items in it
        for (int i = 0; i < tileMapsContainers.Length; i++)
        {
            // Puts the tilemaps into the array
            tileMaps[i] = tileMapsContainers[i].GetComponent<Tilemap>();
        }

        // Loops through as many times as the array has items in it
        for (int i = 0; i < tileMapsContainers.Length; i++)
        {
            // adds the gameobject into a variable
            GameObject tilemapContainer = tileMapsContainers[i];

            // adds the tilemap into a variable
            Tilemap tilemap = tilemapContainer.GetComponent<Tilemap>();

            // Gets what tilemap the player is on
            Vector3Int cellPosition = tilemap.WorldToCell(player.position);

            // Checks if the player is on a tile map by the water
            if (tilemap.HasTile(cellPosition)) 
            {
                // returns the name of the gameobject
                return tilemapContainer.name;
            }
        }

        // if the player is not a tilemap by the water it returns NoWater
        return "NoWater";
    }

    // Gets a random fish depending on what water you stand by
    void Fish(string waterType)
    {
        selectedItem = new string [10];
        for (int i = 0; i < ShopScript.fishLines; i++)
        {
            // If you stand next to fresh water
            if (waterType == "FreshWater")
            {
                // Goes down to the WeightedRandom function below, changing the dictionary to FreshWater found in the FishData script and sets the water type to fresh water
                selectedItem[i] = WeightedRandom(FishData.FreshWater);
            }
            // If you stand next to salt water
            else if (waterType == "SaltWater")
            {
                // Goes down to the WeightedRandom function below, changing the dictionary to SaltWater found in the FishData script and sets the water type to salt water
                selectedItem[i] = WeightedRandom(FishData.SaltWater);
            }

            // Tries to create a new object in the inventory with the fish that got fished up 
            try
            {
                InventoryScript.Inventory.Add(selectedItem[i], 0);

            }
            // If the fish already exits in the inventory it just skips
            catch { }

            // Adds the fish into the inventory
            InventoryScript.Inventory[selectedItem[i]]++;

            // Shows what fish you just caught
            fishActionText.text += $" {selectedItem[i]},";
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Starts when the user presses f
        if (Input.GetKeyDown("f"))
        {
            // Gets if the tile map you are standing on is a water type or not
            string playerWaterType = GetWaterType();

            // Checks if the player is near any water or if there is an active cooldown
            if (playerWaterType != "NoWater" && Time.time > nextEvent)
            {

                // Adds a cooldown
                nextEvent = Time.time + ShopScript.cooldown;

                timer = Time.time + 3;

                cooldownActive = true;

                fishActionText.text = "You just caught a";
                // Gets the random fish
                Fish(playerWaterType);
            }
        }

        if (Time.time > nextEvent) 
        {
            cooldownActive = false;
            cooldownText.text = null;
        }

        if (Time.time > timer) 
        {
            fishActionText.text = null;
        }

        if (cooldownActive)
        {
            double timeLeft = Math.Round(nextEvent - Time.time, 2);
            cooldownText.text = $"Fish Cooldown {timeLeft}s";
        }
        else
        {
        }
    }
    // Creates a function called WeightedRandom while getting information on what dictionary to use
    public static string WeightedRandom(Dictionary<string, int> WeightedDictionary)
    {
        // Creates an int with the starting value 0
        int TotalWeight = 0;

        // Goes through the given dictionary and sums up the total weight/int number all the objects have
        foreach (KeyValuePair<string, int> pair in WeightedDictionary)
        {
            TotalWeight += pair.Value;
        }

        // Makes a new random that chooses between the number 1 and the total of the chosen dictionary
        int chance = UnityEngine.Random.Range(1, TotalWeight + 1);

        // Creates an int with the value 0
        int counter = 0;

        // The weighted random selection process were it goes through each pair and adds the value to counter like TotalWeight did and then compares the chosen random number with the counter and gets the corresponding object
        foreach (KeyValuePair<string, int> pair in WeightedDictionary)
        {
            counter += pair.Value;
            if (chance <= counter)
            {
                // Sends back the random object from the dictionary into the string selectedItem
                return (pair.Key);
            }
        }

        // If I dont have this then not all code paths return a value
        throw new InvalidOperationException("Random selection failed");
    }
}