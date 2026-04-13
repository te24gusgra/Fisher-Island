using JetBrains.Annotations;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public class WeightedRandom
    {

        static Dictionary<string, int> FreshWater = new Dictionary<string, int>()
        {
            ["AngelFish"] = 0,
            ["Bass"] = 0,
            ["CatFish"] = 0,
            ["GoldFish"] = 0,
            ["RainbowTrout"] = 0,
        };
    }
}
