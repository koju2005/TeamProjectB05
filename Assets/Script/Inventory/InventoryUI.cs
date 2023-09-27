using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [Header("Attach Data")]
    public Player player;
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
        var slot = transform.GetChild(0).gameObject;
        slots = new ItemSlotUI[slot.transform.childCount];

        for (int i = 0; i < slot.transform.childCount; ++i)
        {
            var child = slot.transform.GetChild(i);
            slots[i] = child.GetComponent<ItemSlotUI>();
            slots[i].Set(inventory[i]);
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

    public void UseItem(int index )
    {

    }
}
