using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemCraft : MonoBehaviour
{
    public ItemData itemData;
    public string itemName;
    public string itemDescription;
    public Sprite itemImage;

    public Inventory inventory;

    public string[] needItemName;
    public int[] needItemCnt;

    public float itemCraftingTime;

    public GameObject resultItem;

    private void Start()
    {
        itemData = GetComponent<ItemData>();
    }
    public void ItemCrafting()
    {
        
    }
}
