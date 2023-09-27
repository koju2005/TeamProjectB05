using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.Events;
using UnityEngine.UI;

public interface IDamagable
{
    void TakePhysicalDamage(int damageAmount);
}
[System.Serializable]
public class Condition
{
    [HideInInspector]
    public float curValue;
    [HideInInspector]
    public float maxValue;
    public Image uiBar;

    public void Add(float val)
    {
        curValue = Mathf.Min(curValue + val, maxValue);

    }

    public void Subtract(float val)
    {
        curValue = Mathf.Max(curValue - val, 0.0f);
    }

    public float GetPercentage()
    {
        return curValue / maxValue;
    }
}

public class PlayerCondition : MonoBehaviour, IDamagable
{
    public Condition health;
    public Condition stamina;
    public Condition hunger;
    public Condition thirsty;
    public PlayerSO playerSO;

    public UnityEvent onTakeDamage;

    private void Awake()
    {
        playerSO = GetComponent<Player>().playerSO;
    }

    private void Start()
    {
        health.curValue = playerSO.PlayerHP;
        health.maxValue = playerSO.PlayerMaxHP;
        hunger.curValue = playerSO.PlayerHunger;
        hunger.maxValue = playerSO.PlayerMaxHunger;
        stamina.curValue = playerSO.PlayerStamina;
        stamina.maxValue = playerSO.PlayerMaxStamina;
        thirsty.curValue = playerSO.PlayerThirst;
        thirsty.maxValue = playerSO.PlayerMaxThirst;

    }

    private void Update()
    {
        hunger.Subtract(playerSO.deCayRate * Time.deltaTime);
        thirsty.Subtract(playerSO.deCayRate * Time.deltaTime);
        stamina.Add(playerSO.regenRate * Time.deltaTime);
        Debug.Log(stamina.curValue);

        if (hunger.curValue == 0.0f)
        {
            health.Subtract(playerSO.noHungerHealthDecay * Time.deltaTime);
        }
        if (health.curValue == 0.0f)
        {
            Die();
        }

        health.uiBar.fillAmount = health.GetPercentage();
        stamina.uiBar.fillAmount = stamina.GetPercentage();
        hunger.uiBar.fillAmount = hunger.GetPercentage();
        thirsty.uiBar.fillAmount = thirsty.GetPercentage();
    }
    public void Heal(float val)
    {
        health.Add(val);
    }

    public void Eat(float val)
    {
        hunger.Add(val);
    }
    public void Die()
    {

    }
    public void TakePhysicalDamage(int damageAmount)
    {
        health.Subtract(damageAmount);
        onTakeDamage?.Invoke();
    }


}