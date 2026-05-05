using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    //Variables
    public string itemName;
    public int quantity;
    public Sprite itemSprite;

    [SerializeField] 
    private TMP_Text quantityText;

    [SerializeField]
    private Image itemImage;

    public void AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        this.itemName = itemName;
        this.quantity = quantity;
        this.itemSprite = itemSprite;

        quantityText.enabled = true;
        quantityText.text = quantity.ToString();
        itemImage.sprite = itemSprite;
    }
}
