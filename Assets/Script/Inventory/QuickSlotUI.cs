using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSlotUI : ItemSlotUI
{
    public override void Start()
    {
        base.Start();
    }

    public override void Set(ItemSlot slot)
    {
        itemData = slot.Data;
        //icon.gameObject.SetActive(true);
        icon.sprite = slot.Data.icon;
        
    }

    public override void Clear()
    {
        itemData = null;
        //icon.gameObject.SetActive(false);
        icon.sprite = null;
    }
}
