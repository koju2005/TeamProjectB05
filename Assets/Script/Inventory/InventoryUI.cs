using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public ItemSlotUI[] slots;
    private Inventory inventory;
    public ItemSlot currentSlot;

    public GameObject Root;

    private void Awake()
    {
        
    }

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        // �κ��丮�� ��ü(������ ���� ������ ���� �ִ� ���. �÷��̾�, ���� ��)
        inventory = Player.instance.Inventory;

        // �κ��丮�� ���� ��������
        var slot = Root.transform.GetChild(0);
        slots = new ItemSlotUI[slot.transform.childCount];

        // �κ��丮�� �κ��丮UI ������ ����ȭ
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
