using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct ItemAmount
{
    public ItemObject item;
    [Range(1,999)]
    public int Amount;
}

[CreateAssetMenu(fileName = "CraftingRecipe", menuName = "CraftingRecipe")]
public class CraftingRecipe : ScriptableObject
{
    public List<ItemAmount> Materials;
    public List<ItemAmount> Result;

    public bool CanCraft(IItemContainer itemContainer)
    {
        foreach(ItemAmount itemAmount in Materials)
        {
            if(itemContainer.ItemCount(itemAmount.item) <itemAmount.Amount)
            {
                return false;
            }
        }
        return true;
        
    }
    public void Craft(IItemContainer itemContainer)
    {
        if(CanCraft(itemContainer)) 
        {
            foreach (ItemAmount itemAmount in Materials)
            {              
                for(int i = 0; i < itemAmount.Amount; i++)
                {
                    itemContainer.RemoveItem(itemAmount.item);
                }
                
            }
            foreach (ItemAmount itemAmount in Materials)
            {
                for (int i = 0; i < itemAmount.Amount; i++)
                {
                    itemContainer.AddItem(itemAmount.item);
                }
            }
        }

    }
}
