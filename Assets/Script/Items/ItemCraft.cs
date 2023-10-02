using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemCraft : MonoBehaviour
{
    public string itemName;
    public string itemDescription;
    public Sprite itemImage;

    public string[] needItemName;
    public int[] needItemCnt;

    public float itemCraftingTime;

    public GameObject resultItem;




    public void ItemCrafting()
    {

    }

}
