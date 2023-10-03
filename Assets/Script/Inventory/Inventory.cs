using OpenCover.Framework.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

[System.Serializable]
public class ItemSlot
{
    public ItemObject itemObj;
    public int quantity;
    
    public ItemData Data { get { return itemObj.item; } }
    
    public ItemSlot()
    {
        itemObj = new ItemObject();
        quantity = 0;
    }
}

public class Inventory:IItemContainer
{
    private ItemSlot[] _inventory;
    private int _maxSize;
    private int _size;
    private int _cursor;

    public ItemSlot currentItem;
    public int _currentItemIndex;

    //public static Inventory instance;
    public ItemSlot this[int index]
    {
        get
        {
            if (index >= _maxSize)
                return _inventory[_maxSize - 1];
            return _inventory[index];
        }
    }
    public int MaxSize{ get { return _maxSize; } }

    public Inventory(int size)
    {
        _cursor = 0;
        _size = 0;
        _maxSize = size;
        _inventory = new ItemSlot[size];
        currentItem = new ItemSlot();

        for (int i = 0; i < size; ++i)
        {
            _inventory[i] = new ItemSlot();
        }
    }

    public void AddItem(ItemObject itemObj)
    {
        if (_size >= _maxSize)
            return;

        bool isStack = false;
        bool isEmpty = ContainItem(itemObj);

        for (int i=0; i< _maxSize; ++i)
        {
            if (_inventory[i].itemObj == null)
                continue;

            if (_inventory[i].itemObj.item.name == itemObj.item.name)
            {
                if (_inventory[i].quantity >= itemObj.item.maxStackAmount)
                {
                    isStack = true;
                }
                else if (_inventory[i].quantity < itemObj.item.maxStackAmount)
                {
                    isStack = false;
                    _inventory[i].quantity += 1;
                    break;
                }
            }
            else
            {
                isStack = true;
            }
        }

        if (isStack || (!isEmpty))
        {
            UpdateCursor();
            _inventory[_cursor].itemObj = itemObj;
            _inventory[_cursor].quantity = 1;
            _size++;
        }
        

    }

    public void AddItems(IEnumerable<ItemSlot> items)
    {
        foreach(var obj in items)
        {
            AddItem(obj.itemObj);
        }
    }

    public void RemoveItem(int index)
    {

        _inventory[index] = null;
    }
    
    public void UpdateCursor(int index)
    {
        _cursor = (_cursor >= index) ? index : _cursor;

        if (_inventory[index].itemObj.item.canStack && _inventory[index].quantity <= 0)
            _inventory[index].quantity -= 1;
        else
            _inventory[index] = null;

    }

    public void UpdateCursor()
    {
        for(int i=0; i<_maxSize; ++i)
        {
            if (_inventory[i].Data == null)
            {
                _cursor = i; //UpdateCursor(i);
                break;
            }
        }
    }

    public void SetCurrentItem(int index)
    {
        currentItem = _inventory[index];
    }

    public bool ContainItem(ItemObject itemObj)
    {
        foreach (var obj in _inventory)
        {
            if (obj.itemObj == null)
                continue;

            if (obj.itemObj.item.name == itemObj.item.name)
            {
                return true;
            }
        }
        return false;
    }
    public int ItemCount(ItemObject item)
    {
        int number = 0;
        for(int i=0; i< _inventory.Length;i++)
        {
            if (_inventory[i].itemObj == item)
            {
                number++;
            }
        }
        return number;
    }
    public void RemoveItem(ItemObject item)
    {
        for(int i=0;i< _inventory.Length; i++)
        {
            if (_inventory[i].itemObj == item)
            {
                _inventory[i].itemObj = null;
            }
        }
    }
}