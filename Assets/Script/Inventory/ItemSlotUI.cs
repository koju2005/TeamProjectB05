using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    public Button button;
    public Image icon;
    public TextMeshProUGUI quatityText;

    public int index;

    private GameObject _rootObj;

    protected InventoryUI invenUI;
    protected ItemData itemData;

    public virtual void Start()
    {

    }

    private void OnEnable()
    {

    }

    public void SetRootObject(GameObject rootObj)
    {
        _rootObj = rootObj;
        invenUI = _rootObj.GetComponent<InventoryUI>();
    }

    public virtual void Set(ItemSlot slot)
    {
        button.enabled = true;
        itemData = slot.Data;
        //icon.gameObject.SetActive(true);
        icon.sprite = slot.Data.icon;
        quatityText.text = slot.quantity > 1 ? slot?.quantity.ToString() : string.Empty;
    }

    public virtual void Clear()
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