using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public ItemSlotUI[] slots;
    private Inventory _inventory;

    public GameObject Root;

    public ItemSlot SelectItem {  get { return _inventory.currentItem; } }

    private void Awake()
    {

    }

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        // 인벤토리 내용물의 주체
        _inventory = Player.instance.Inventory;

        // 인벤토리의 슬롯 가져오기
        var slot = Root.transform.GetChild(0);
        slots = new ItemSlotUI[slot.transform.childCount];

        // 인벤토리와 인벤토리UI 데이터 동기화
        for (int i = 0; i < slot.transform.childCount; ++i)
        {
            var child = slot.transform.GetChild(i);
            slots[i] = child.GetComponent<ItemSlotUI>();
            slots[i].SetRootObject(Root);

            if (_inventory[i].Data != null)
                slots[i].Set(_inventory[i]);
            else
                slots[i].Clear();
            slots[i].index = i;
        }

        Debug.Log(_inventory[0].Data.displayName);
    }

    public void SelectedItem(int index)
    {
        if (_inventory[index].Data == null)
            Debug.Log("is null");

        _inventory.SetCurrentItem(index);

        UIManager.instance.ShowItemInfo();
    }

    public void UpdateItem()
    {
        for(int i=0; i<slots.Length;++i)
        {
            slots[i].Set(_inventory[i]);
            slots[i].index = i;
        }
    }
}
