using System.Collections;
using System.Collections.Generic;
using System.Xml;
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

    private void OnEnable()
    {
        UpdateItem();
    }

    private void Initialize()
    {
        // �κ��丮 ���빰�� ��ü
        _inventory = Player.instance.Inventory;

        // �κ��丮�� ���� ��������
        var slot = Root.transform.GetChild(0);
        slots = new ItemSlotUI[slot.transform.childCount];

        // �κ��丮�� �κ��丮UI ������ ����ȭ
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
        for (int i = 0; i < slots.Length; ++i)
        {
            if (_inventory[i].Data != null)
                slots[i].Set(_inventory[i]);
            else
                slots[i].Clear();
        }
    }
}
