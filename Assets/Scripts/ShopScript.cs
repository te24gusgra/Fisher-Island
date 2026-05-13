using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Tilemaps;

public class ShopScript : MonoBehaviour
{
    // Variables
    static public float money = 0;
    static public string playerShopArea;
    static public bool shopActivated;

    // Upgradeable variables
    static public int fishLines = 1;
    [HideInInspector]
    static public float cooldown = 5;
    static public float moneyMultiplier = 1;

    // Getting outside information
    public GameObject shopMenu;

    public Transform player;

    [SerializeField]
    private TMP_Text totalMoney;

    [SerializeField]
    private TMP_Text sellActionText;

    // Creating arrays
    GameObject[] tileMapsContainers;
    Tilemap[] tileMaps;

    //  Figuring out if the player is on a tile next to the shop
    string GetShopArea()
    {
        // Getting the gameobjects with the tag ShopArea
        tileMapsContainers = GameObject.FindGameObjectsWithTag("ShopArea");

        // Recreates the array with the same length as there are with the tag ShopArea
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
            // adds the gameobjects into a variable
            GameObject tilemapContainer = tileMapsContainers[i];

            // adds the tilemap into a variable
            Tilemap tilemap = tilemapContainer.GetComponent<Tilemap>();

            // Gets what tilemap the player is on
            Vector3Int cellPosition = tilemap.WorldToCell(player.position);

            // Checks if the player is on the tile map by the shop
            if (tilemap.HasTile(cellPosition))
            {
                // returns the name of the gameobject
                return "ShopArea";
            }
        }

        // if the player is not the tilemap by the shop it returns NoShopArea
        return null;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Checks how much money you have in total and displays it
        totalMoney.text = $"${money.ToString()}";

        // Gets if the tile map you are standing on is near the shop or not
        playerShopArea = GetShopArea();

        if (Input.GetKeyDown("f"))
        {

            // Checks if the player is near the shop
            if (playerShopArea == "ShopArea")
            {
                
            }
        }

        if (Input.GetKeyDown("e")) 
        {
            if (playerShopArea == "ShopArea" && !shopActivated)
            {
                shopMenu.SetActive(true);
                shopActivated = true;
            }
            else if (playerShopArea == "ShopArea" && shopActivated)
            {
                shopMenu.SetActive(false);
                shopActivated= false;
            }
        }
        if (playerShopArea == null)
        {
            shopMenu.SetActive(false);
            shopActivated = false;
            sellActionText.text = null;
        }
    }
}
