using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    // Variables
    static bool menuActivated;

    // Creating an array
    public ItemSlot[] itemSlotArray;

    // Getting the gameobjects
    public GameObject InventoryMenu;
    public GameObject InventorySlotsContainer;
    public GameObject IventorySlotPrefab;

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
        if (Input.GetKeyDown("e") && menuActivated)
        {

            // Clear All itemslots in inventory
            for (var i = InventorySlotsContainer.transform.childCount - 1; i >= 0; i--)
            {
                Destroy(InventorySlotsContainer.transform.GetChild(i).gameObject);
                Destroy(itemSlotArray[0]);
            }

            // Disables inventory
            InventoryMenu.SetActive(false);
            menuActivated = false;

            // Removes the fishs description
            DeselectDescription();
        }
        else if (Input.GetKeyDown("e") && !menuActivated)
        {
            // Recreates the array with the length of 10
            itemSlotArray = new ItemSlot[10];

            // Creates the int with the value 0
            int i = 0;

            // Creates copys of an inventory slot prefab based on how many different fish you have in your inventory and pass the fish, quantity, fish sprite, fish description and the sell value onto another function
            foreach (KeyValuePair<string, int> pair in Inventory)
            {
                var itemSlot = Instantiate(IventorySlotPrefab, InventorySlotsContainer.transform);
                ItemSlot itemSlotComponent = itemSlot.GetComponent<ItemSlot>();
                itemSlotComponent.AddItem(pair.Key, pair.Value, FishData.FishSprites[pair.Key], FishData.FishDescriptions[pair.Key], FishData.SellValues[pair.Key]);

                // Adds the itemslot into the array
                itemSlotArray[i] = itemSlotComponent;
                i++;
            }

            // Enables inventory
            InventoryMenu.SetActive(true);
            menuActivated = true;
        }
    }

    // Deselects all slots in inventory
    public void DeselectAllSlots()
    {
        // Loops through each item in the array
        for (int i = 0; i < itemSlotArray.Length; i++)
        {
            // Skips if there is no item slot in that position
            if (itemSlotArray[i] != null)
            {
                // Disables the part that makes you see if you selected a fish
                itemSlotArray[i].selectedShader.SetActive(false);
                itemSlotArray[i].thisItemSelected = false;
            }
        }
    }

    // Removes the fishs description
    public void DeselectDescription()
    {
        // Loops through the array
        for (int i = 0; i < itemSlotArray.Length; i++)
        {
            // Skips if there is no item slot in that position
            if (itemSlotArray[i] != null)
            {
                // Sets all the fishes description values to null or disables the text
                itemSlotArray[i].fishDescriptionImage.enabled = false;
                itemSlotArray[i].fishDescriptionNameText.text = null;
                itemSlotArray[i].fishDescriptionText.text = null;
                itemSlotArray[i].fishValueText.text = null;
            }
        }
    }
}