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
        Inventory.instance.AddItem(this);// �κ��丮�� AddItem�� �Ű������� Itemobject�� �ƴ϶� ItemData�� �޾ƿü��ְ� �ؾ��Ҳ������ϴ�
        Destroy(gameObject);
    }
}

