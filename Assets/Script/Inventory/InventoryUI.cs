using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public ItemSlotUI[] slots;
    private Inventory inventory;
    public ItemSlot currentSlot;

    private void Awake()
    {
        
    }

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        inventory = Player.instance.Inventory;

        var slot = UIManager.instance.invenory.transform.GetChild(0);
        slots = new ItemSlotUI[slot.transform.childCount];

        for (int i = 0; i < slot.transform.childCount; ++i)
        {
            var child = slot.transform.GetChild(i);
            slots[i] = child.GetComponent<ItemSlotUI>();

            if (inventory[i].Data != null)
                slots[i].Set(inventory[i]);
            else
                slots[i].Clear();
            slots[i].index = i;
        }
    }

    public void SelectedItem(int index)
    {
        if (inventory[index] == null)
            return;

    }

    public void UpdateItem()
    {
        for(int i=0; i<slots.Length;++i)
        {
            slots[i].Set(inventory[i]);
            slots[i].index = i;
        }
    }
}
