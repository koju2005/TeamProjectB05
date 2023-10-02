using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.Profiling.Memory.Experimental;
using System;
using UnityEngine.Tilemaps;

public class ItemInfoUI : MonoBehaviour
{
    public GameObject inventoryObj;
    private bool _isEquip;

    private Action _behaviorFunc;

    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _desc;
    [SerializeField] private TextMeshProUGUI _behavior;

    public List<GameObject> _buttons;

    // Start is called before the first frame update
    private void Awake()
    {

    }

    private void Start()
    {
    }

    private void OnEnable()
    {
        SetDisplayElements();      
    }

    private void OnDisable()
    {
        _behaviorFunc = null;
        ClearDisplayElements();
    }

    private void SetDisplayElements()
    {
        var _current = Player.instance.Inventory.currentItem;

        _name.text = _current.Data.displayName;
        _desc.text = _current.Data.description;


        bool isActiveable = true;
        switch (_current.Data.type)
        {
            case ItemType.Equipable:
                _isEquip = CheckEquipable();
                if (_isEquip)
                    _behavior.text = "Equip";
                else
                    _behavior.text = "Unequip";
                _behaviorFunc += UseEquip;
                break;
            case ItemType.Consumable:
                _behavior.text = "Consume";
                _behaviorFunc += UseConsumable;
                break;
            case ItemType.Resource:
                isActiveable = false;
                _behaviorFunc += UseResource;
                break;
        }

        _buttons[0].gameObject.SetActive(isActiveable);
        if (_current.Data.dropPrefab != null)
            _buttons[1].gameObject.SetActive(true);

    }

    private void ClearDisplayElements()
    {
        _name.text = string.Empty;
        _desc.text = string.Empty;
        _isEquip = false;

        foreach (var obj in _buttons)
            obj.gameObject.SetActive(false);
    }

    public void Behavior()
    {
        _behaviorFunc.Invoke();
    }

    private void UseEquip()
    {
        if (_isEquip) Debug.Log("UseItemEquip");
        else Debug.Log("UseItemUnequip");
    }

    public bool CheckEquipable()
    {
        var _current = Player.instance.Inventory.currentItem;
        return !Player.instance.Equip.ContainItem(_current.itemObj);
    }

    private void UseConsumable()
    {
        Debug.Log("UseConsumableItem");
    }

    private void UseResource()
    {
        Debug.Log("UseConsumableItem");
    }

    private void UseDrop()
    {
        
    }
}
