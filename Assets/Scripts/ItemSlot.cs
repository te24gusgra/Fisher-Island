using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //Variables
    public string fishName;
    public int quantity;
    public Sprite fishSprite;
    public string fishDescription;
    public int fishValue;

    //Item slot stuff
    [SerializeField]
    private TMP_Text quantityText;

    [SerializeField]
    private Image fishImage;

    //Item description
    public Image fishDescriptionImage;
    public TMP_Text fishValueText;
    public TMP_Text fishDescriptionNameText;
    public TMP_Text fishDescriptionText;


    public GameObject selectedShader;
    public bool thisItemSelected;

    private InventoryScript inventoryScript;

    public void Start()
    {
        inventoryScript = GameObject.Find("InventoryCanvas").GetComponent<InventoryScript>();
        fishDescriptionNameText = GameObject.Find("FishDescriptionNameText").GetComponentInChildren<TMP_Text>();
        fishDescriptionText = GameObject.Find("FishDescriptionText").GetComponentInChildren<TMP_Text>();
        fishDescriptionImage = GameObject.Find("DescriptionFishImage").GetComponentInChildren<Image>();
        fishValueText = GameObject.Find("FishValueText").GetComponentInChildren<TMP_Text>();
    }

    public void AddItem(string fishName, int quantity, Sprite fishSprite, string fishDescription, int fishValue)
    {
        this.fishName = fishName;
        this.quantity = quantity;
        this.fishSprite = fishSprite;
        this.fishDescription = fishDescription;
        this.fishValue = fishValue;

        quantityText.enabled = true;
        quantityText.text = quantity.ToString();
        fishImage.sprite = fishSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnLeftClick();
    }

    public void OnLeftClick()
    {
        inventoryScript.DeselectAllSlots();
        selectedShader.SetActive(true);
        thisItemSelected = true;
        fishDescriptionNameText.text = fishName;
        fishDescriptionText.text = fishDescription;
        fishDescriptionImage.sprite = fishSprite;
        fishDescriptionImage.enabled = true;
        fishValueText.text = $"${fishValue.ToString()}";
    }
}
