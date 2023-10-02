using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct ItemAmount
{
    public ItemData item;
    [Range(1,999)]
    public int Amount;
}

[CreateAssetMenu(fileName = "CraftingRecipe", menuName = "CraftingRecipe")]
public class CraftingRecipe : ScriptableObject
{
    public List<ItemAmount> Materials;
    public List<ItemAmount> Result;

    public bool CanCraft(Inventory inventory)
    {
        return false;
    }
    public void Craft(Inventory inventory)
    {

    }
}
