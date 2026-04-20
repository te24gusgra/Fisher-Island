using System.Collections.Generic;
using UnityEngine;

public class FishLootTables : MonoBehaviour
{
    //Creates a dictionary that holds pairs with a string/key and an int/value with the string being the name of the fish and the int being the chance of it being chosen
    static public Dictionary<string, int> FreshWater = new Dictionary<string, int>()
    {
        ["AngelFish"] = 24,
        ["Bass"] = 40,
        ["CatFish"] = 30,
        ["GoldFish"] = 5,
        ["RainbowTrout"] = 1,
    };

    //Same as above but with other fish and chances
    static public Dictionary<string, int> SaltWater = new Dictionary<string, int>()
    {
        ["Anchovy"] = 40,
        ["Clownfish"] = 20,
        ["Crab"] = 5,
        ["Pufferfish"] = 10,
        ["Surgeon"] = 25,
    };

   /* static public Dictionary<string, int> MuddPuddle = new Dictionary<string, int>()
    {
        ["RustyCan"] = 95,
        ["Worm"] = 5,
    };*/

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
