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
        // 인벤토리의 주체(아이템 보유 정보를 갖고 있는 대상. 플레이어, 상자 등)
        inventory = Player.instance.Inventory;

        // 인벤토리의 슬롯 가져오기
        var slot = Root.transform.GetChild(0);
        slots = new ItemSlotUI[slot.transform.childCount];

        // 인벤토리와 인벤토리UI 데이터 동기화
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
