using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData item;

    public string GetInteractPromt()
    {
        return string.Format("Pickup {0}", item.displayName);
    }


    public void OnInteract()
    {
        if(item.displayName == "Water")
        {
            GameManager.instance.player.GetComponent<PlayerCondition>().thirsty.Add(10f);
        }
        else
        Player.instance.Inventory.AddItem(this);
        //Destroy(gameObject);
    }


    public ItemObject()
    {
        item = null;
    }

    public ItemObject(ItemData data)
    {
        item = data;

    }

    public string GetInteractPrompt()
    {
        return string.Format("Pickup {0}", item.displayName);
    }

}

