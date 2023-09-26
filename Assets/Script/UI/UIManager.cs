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
    }
    private void ShowUI(GameObject obj)
    {
        if(obj.activeSelf==false)
        obj.SetActive(true);
        else
        obj.SetActive(false);
    }

    private void ShowInven(GameObject obj, GameObject obj2)
    {
        if (obj.activeSelf == false)
        {
            obj2.SetActive(false);
            obj.SetActive(true);
        }
        else
        {
            obj2.SetActive(true);
            obj.SetActive(false);
        }
    }
}
