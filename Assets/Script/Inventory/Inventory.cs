using OpenCover.Framework.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


public class ItemSlot
{
    public ItemObject itemObj;
    public int quantity;
    
    public ItemData Data { get { return itemObj.item; } }

}

public class Inventory
{
    private ItemSlot[] _inventory;
    private int _size;

    public ItemSlot this[int index]
    {
        get
        {
            if (index >= _size)
                return _inventory[_size-1];
            return _inventory[index];
        }
    }

    public Inventory(int size)
    {
        for(int i=0; i<size; ++i)
        {
            _inventory[i] = new ItemSlot();
        }
    }

    public Inventory(ItemObject[] items)
    {
        for(int i=0; i<items.Length; i++)
        {
            _inventory[i] = new ItemSlot()
            {
                itemObj = items[i],
                quantity = 1
            };
        }
    }

    public void AddItem(ItemObject item)
    {
        for(int i=0; i<_inventory.Length; ++i)
        {

        }
    }

    public void RemoveItem(int index)
    {

    }

    //public Inventory(ItemSlot[] inventory)
    //{
    //    for(int i=0; i<inventory.Length; i++)
    //    {
    //        _inventory[i] = new ItemSlot();
    //        _inventory[i] = inventory[i];
    //    }
    //}
}