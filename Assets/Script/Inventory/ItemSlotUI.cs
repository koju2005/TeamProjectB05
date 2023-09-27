using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    public Button button;
    public Image icon;
    public TextMeshProUGUI quatityText;

    public int index;

    private InventoryUI invenUI;
    private ItemData itemData;

    private void Awake()
    {
        //invenUI = UIManager.instance;
    }

    private void OnEnable()
    {

    }

    public void Set(ItemSlot slot)
    {
        itemData = slot.Data;
        icon.gameObject.SetActive(true);
        icon.sprite = slot.Data.icon;
        quatityText.text = slot.quantity > 1 ? slot.quantity.ToString() : string.Empty;
    }

    public void Clear()
    {
        itemData = null;
        icon.gameObject.SetActive(false);
        icon.sprite = null;
        quatityText.text = string.Empty;
    }

    public void OnSelected()
    {
        invenUI.UseItem(index);
    }
}