using System.Collections.Generic;
using UnityEngine;

public class FishLootTables : MonoBehaviour
{

    static public Dictionary<string, int> FreshWater = new Dictionary<string, int>()
    {
        ["AngelFish"] = 24,
        ["Bass"] = 40,
        ["CatFish"] = 30,
        ["GoldFish"] = 5,
        ["RainbowTrout"] = 1,
    };

    static public Dictionary<string, int> SaltWater = new Dictionary<string, int>()
    {
        ["Anchovy"] = 40,
        ["Clownfish"] = 30,
        ["Crab"] = 5,
        ["Pufferfish"] = 10,
        ["Surgeon"] = 15,
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
