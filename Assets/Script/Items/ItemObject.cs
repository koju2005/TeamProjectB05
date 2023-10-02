using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData item;

    public string GetInteractPromt()
    {
        return string.Format("Pickup {0}", item.displayName);
    }

    //public void OnInteract()
    //{
    //    Destroy(gameObject);

    //}
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

    public void OnInteract()
    {
        Inventory.instance.AddItem(this);// 인벤토리의 AddItem의 매개변수를 Itemobject가 아니라 ItemData를 받아올수있게 해야할꺼같습니다
        Destroy(gameObject);
    }
}

