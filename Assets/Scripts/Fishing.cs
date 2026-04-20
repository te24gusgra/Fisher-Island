using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    // Getting the dictionaries
    public FishLootTables fishLootTables;

    //Variables
    public string selectedItem;
    public string waterType;
    public int rand;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Chooses the number 1 or 2
        rand = UnityEngine.Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        //Starts when the user presses r
        if (Input.GetKeyDown("f"))
        {
            if (rand == 1)
            {
                //Goes down to the function below, changing the dictionary to FreshWater found in the FishLootTables script and sets the water type to fresh water
                selectedItem = WeightedRandom(FishLootTables.FreshWater);
                waterType = "FreshWater";
            }
            else
            {
                //Goes down to the function below, changing the dictionary to SaltWater found in the FishLootTables script and sets the water type to salt water
                selectedItem = WeightedRandom(FishLootTables.SaltWater);
                waterType = "SaltWater";
            }

            //Prints out what type of water you fished in and what you got in the console
            Debug.Log($"You fished in {waterType} and got a {selectedItem}");
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