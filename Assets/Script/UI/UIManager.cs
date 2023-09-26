using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;
    public GameObject map;//맵
    public GameObject invenory;//인벤
    public GameObject quickslot;//퀵슬롯
    public GameObject prod;//제작창
    public GameObject equip;//장비창
    public GameObject InvenHud;//E버튼 입력시 생기는 모든 개체
    public GameObject itemInfo;//아이템정보
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ShowUI(InvenHud);
    }
    public void Map()
    {
        ShowUI(map);
    }
    public void Inven()
    {
        ShowInven(InvenHud, quickslot);
        itemInfo.SetActive(false);
    }
    private void ShowUI(GameObject obj)
    {
        if(obj.activeSelf==false)
        obj.SetActive(true);
        else
        obj.SetActive(false);
    }

    public void CansleInfo()
    {
        itemInfo.SetActive(false);
    }
    private void ShowInven(GameObject obj, GameObject obj2)
    {
       
        if (obj.activeSelf == false)
        {
            obj2.SetActive(false);
            obj.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            obj2.SetActive(true);
            obj.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
