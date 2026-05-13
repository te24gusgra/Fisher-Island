using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FishData : MonoBehaviour
{
    // Contains the differents fishes sprites and descriptions

    [SerializeField]
    public Sprite anchovy;

    [TextArea]
    [SerializeField]
    private string anchovyDescription;

    [SerializeField]
    public Sprite angelFish;

    [TextArea]
    [SerializeField]
    private string angelFishDescription;

    [SerializeField]
    public Sprite bass;

    [TextArea]
    [SerializeField]
    private string bassDescription;

    [SerializeField]
    public Sprite catFish;

    [TextArea]
    [SerializeField]
    private string catFishDescription;

    [SerializeField]
    public Sprite clownFish;

    [TextArea]
    [SerializeField]
    private string clownFishDescription;

    [SerializeField]
    public Sprite crab;

    [TextArea]
    [SerializeField]
    private string crabDescription;

    [SerializeField]
    public Sprite goldFish;

    [TextArea]
    [SerializeField]
    private string goldFishDescription;

    [SerializeField]
    public Sprite pufferFish;

    [TextArea]
    [SerializeField]
    private string pufferFishDescription;

    [SerializeField]
    public Sprite rainbowTrout;

    [TextArea]
    [SerializeField]
    private string rainbowTroutDescription;

    [SerializeField]
    public Sprite surgeon;

    [TextArea]
    [SerializeField]
    private string surgeonDescription;

    // Creates a dictionary that holds pairs with a string/key and an int/value with the string being the name of the fish and the int being the chance of it being chosen
    static public Dictionary<string, int> FreshWater = new Dictionary<string, int>()
    {
        ["Angelfish"] = 24,
        ["Bass"] = 40,
        ["Catfish"] = 30,
        ["Goldfish"] = 5,
        ["Rainbowtrout"] = 1,
    };

    // Same as above but with other fish and chances
    static public Dictionary<string, int> SaltWater = new Dictionary<string, int>()
    {
        ["Anchovy"] = 40,
        ["Clownfish"] = 20,
        ["Crab"] = 5,
        ["Pufferfish"] = 10,
        ["Surgeon"] = 25,
    };

    // Same as above but with all the fish combined and with the fishs sell value
    static public Dictionary<string, int> SellValues = new Dictionary<string, int>()
    {
        ["Anchovy"] = 5,
        ["Angelfish"] = 12,
        ["Bass"] = 5,
        ["Catfish"] = 8,
        ["Clownfish"] = 15,
        ["Crab"] = 75,
        ["Goldfish"] = 75,
        ["Pufferfish"] = 30,
        ["Rainbowtrout"] = 150,
        ["Surgeon"] = 10,
    };

    // Creates dictionaries
    static public Dictionary<string, Sprite> FishSprites;
    static public Dictionary <string, string> FishDescriptions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Stores each fish sprite
        FishSprites = new Dictionary<string, Sprite>()
        {
            ["Anchovy"] = anchovy,
            ["Angelfish"] = angelFish,
            ["Bass"] = bass,
            ["Catfish"] = catFish,
            ["Clownfish"] = clownFish,
            ["Crab"] = crab,
            ["Goldfish"] = goldFish,
            ["Pufferfish"] = pufferFish,
            ["Rainbowtrout"] = rainbowTrout,
            ["Surgeon"] = surgeon,
        };

        // Stores each fish description
        FishDescriptions = new Dictionary<string, string>()
        {
            ["Anchovy"] = anchovyDescription,
            ["Angelfish"] = angelFishDescription,
            ["Bass"] = bassDescription,
            ["Catfish"] = catFishDescription,
            ["Clownfish"] = clownFishDescription,
            ["Crab"] = crabDescription,
            ["Goldfish"] = goldFishDescription,
            ["Pufferfish"] = pufferFishDescription,
            ["Rainbowtrout"] = rainbowTroutDescription,
            ["Surgeon"] = surgeonDescription,
        };
    }

    // Update is called once per frame
    void Update()
    {
    }
}
