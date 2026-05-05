using System.Collections.Generic;
using UnityEngine;

public class FishData : MonoBehaviour
{
    [SerializeField]
    public Sprite anchovy;

    [SerializeField]
    public Sprite angelFish;

    [SerializeField]
    public Sprite bass;

    [SerializeField]
    public Sprite catFish;

    [SerializeField]
    public Sprite clownFish;

    [SerializeField]
    public Sprite crab;

    [SerializeField]
    public Sprite goldFish;

    [SerializeField]
    public Sprite pufferFish;

    [SerializeField]
    public Sprite rainbowTrout;

    [SerializeField]
    public Sprite surgeon;

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

    static public Dictionary<string, int> SellValues = new Dictionary<string, int>()
    {
        ["Anchovy"] = 5,
        ["AngelFish"] = 12,
        ["Bass"] = 5,
        ["CatFish"] = 8,
        ["Clownfish"] = 15,
        ["Crab"] = 75,
        ["GoldFish"] = 75,
        ["Pufferfish"] = 30,
        ["RainbowTrout"] = 150,
        ["Surgeon"] = 10,
    };

    static public Dictionary<string, Sprite> FishSprites;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        FishSprites = new Dictionary<string, Sprite>()
        {
            ["Anchovy"] = anchovy,
            ["AngelFish"] = angelFish,
            ["Bass"] = bass,
            ["CatFish"] = catFish,
            ["Clownfish"] = clownFish,
            ["Crab"] = crab,
            ["GoldFish"] = goldFish,
            ["Pufferfish"] = pufferFish,
            ["RainbowTrout"] = rainbowTrout,
            ["Surgeon"] = surgeon,
        };
    }

    // Update is called once per frame
    void Update()
    {
    }
}
