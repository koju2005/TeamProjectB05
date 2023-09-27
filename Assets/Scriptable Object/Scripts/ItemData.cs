using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public enum ItemType
{
    Resource,
    Equipable,
    Consumable,
    structure,
}
public enum ConsumableType
{
    Hunger,
    thirsty,
    Health
}

[CreateAssetMenu(fileName ="Item",menuName ="New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public ItemType type;
    public Sprite icon;
    public GameObject dropPrefab;

    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount;
}
