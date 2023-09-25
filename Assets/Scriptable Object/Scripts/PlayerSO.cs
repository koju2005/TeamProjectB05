using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "Scriptable Object/Player Data", order = int.MinValue)]
public class PlayerSO : ScriptableObject
{
    [Header("Info")]
    public float PlayerHP;
    public float PlayerSpeed;
    public float PlayerHunger;
    public float PlayerStamina;
    public float PlayerThirst;
    public float PlayerMaxHP;
    public float PlayerMaxHunger;
    public float PlayerMaxStamina;
    public float PlayerMaxThirst;
    public float deCayRate;
    public float regenRate;
    public float noHungerHealthDecay;
}   
