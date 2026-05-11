using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    static bool menuActivated;
    public ItemSlot[] itemSlotArray;

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
            // Disable inventory

            // Clear All itemslots in inventory
            for (var i = InventorySlotsContainer.transform.childCount - 1; i >= 0; i--)
            {
                Destroy(InventorySlotsContainer.transform.GetChild(i).gameObject);
                Destroy(itemSlotArray[0]);
            }
            

            InventoryMenu.SetActive(false);
            menuActivated = false;
        }
        else if (Input.GetKeyDown("e") && !menuActivated)
        {
            // Enable inventory

            itemSlotArray = new ItemSlot[10];
            int i = 0;

            // Creates copys of an inventory prefab and adds the fish and the quantity
            foreach (KeyValuePair<string, int> pair in Inventory)
            {
                var itemSlot = Instantiate(IventorySlotPrefab, InventorySlotsContainer.transform);
                ItemSlot itemSlotComponent = itemSlot.GetComponent<ItemSlot>();
                itemSlotComponent.AddItem(pair.Key, pair.Value, FishData.FishSprites[pair.Key], FishData.FishDescriptions[pair.Key]);

                itemSlotArray[i] = itemSlotComponent;
                i++;
            }

            InventoryMenu.SetActive(true);
            menuActivated = true;
        }
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlotArray.Length; i++)
        {
            if (itemSlotArray[i] != null)
            {
                itemSlotArray[i].selectedShader.SetActive(false);
                itemSlotArray[i].thisItemSelected = false;
            }
        }
    }
}