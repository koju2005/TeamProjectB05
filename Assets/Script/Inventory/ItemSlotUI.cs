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

    private void Start()
    {
        // 아이템 선택시 InventoryUI에서 로직 처리를 하기 위해 선언
        // 현재 UIManager쪽이 변경되어 수정 예정
        GameObject root = UIManager.instance.invenory;
        invenUI = root.GetComponentInChildren<InventoryUI>();
    }

    private void OnEnable()
    {

    }

    public void Set(ItemSlot slot)
    {
        button.enabled = true;
        itemData = slot.Data;
        //icon.gameObject.SetActive(true);
        icon.sprite = slot.Data.icon;
        quatityText.text = slot.quantity > 1 ? slot?.quantity.ToString() : string.Empty;
    }

    public void Clear()
    {
        button.enabled = false;
        itemData = null;
        //icon.gameObject.SetActive(false);
        icon.sprite = null;
        quatityText.text = string.Empty;
    }

    public void OnSelected()
    {
        invenUI.SelectedItem(index);
    }
}