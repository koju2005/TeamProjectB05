using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;
    public GameObject map;//��
    public GameObject invenory;//�κ�
    public GameObject quickslot;//������
    public GameObject prod;//����â
    public GameObject equip;//���â
    public GameObject InvenHud;//E��ư �Է½� ����� ��� ��ü
    public GameObject itemInfo;//����������
    public GameObject prodInfo;//��������
    public GameObject bulidInfo;//��ġ
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ShowUI(InvenHud);
        ShowUI(bulidInfo);
    }
    public void Map()
    {
        ShowUI(map);
    }
    public void Bulid()
    {
        ShowUI(bulidInfo);
    }
    public void ShowItemInfo()
    {
        ShowInfo(itemInfo);
    }
    public void ShowProdInfo()
    {
        ShowInfo(prodInfo);
    }
    public void BackItemInfo()
    {
        CansleInfo(itemInfo);
    }
    public void BackProdInfo()
    {
        CansleInfo(prodInfo);
    }
    public void Inven()
    {
        ShowInven(InvenHud, quickslot);
        itemInfo.SetActive(false);
        prodInfo.SetActive(false);
    }
    private void ShowUI(GameObject obj)
    {
        if(obj.activeSelf==false)
        obj.SetActive(true);
        else
        obj.SetActive(false);
    }

    private void ShowInfo(GameObject obj)
    {
        obj.SetActive(true);
    }
    private void CansleInfo(GameObject obj)
    {
        obj.SetActive(false);
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
