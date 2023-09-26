using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewObject : MonoBehaviour
{
    [SerializeField]
    private List<Collider> colliderList = new List<Collider>();

    [SerializeField]
    private int layerGround; // 지형 레이어 (무시하게 할 것)
    private const int IGNORE_RAYCAST_LAYER = 2;  // ignore_raycast (무시하게 할 것)

    [SerializeField]
    private Material green;
    [SerializeField]
    private Material red;

    public bool isRotatable;
    private bool needTypeFlag;
    private Vector3 targetPosition;
    public Building.Type needType;
    private List<Material> materials = new List<Material>();

    private void Start()
    {
        materials.Add(green);
        GetComponent<MeshRenderer>().SetMaterials(materials);
    }

    void Update()
    {
        ChangeColor();
    }

    private void ChangeColor()
    {
        if (needType == Building.Type.Normal)
        {
            if (colliderList.Count > 0)
                SetColor(red);
            else
                SetColor(green);
        }
        else
        {
            if (colliderList.Count > 0 || !needTypeFlag)
                SetColor(red);
            else
                SetColor(green);
        }
    }

    private void SetColor(Material mat)
    {
        materials[0] = mat;
        GetComponent<MeshRenderer>().SetMaterials(materials);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Structure")
        {
            if (other.GetComponent<Building>().type == needType)
            {
                if (needType != Building.Type.Normal)
                {
                    targetPosition = other.transform.position;
                }
                needTypeFlag = true;
            }
            else
                colliderList.Add(other);
        }
        else
        {
            if (other.gameObject.layer != layerGround && other.gameObject.layer != IGNORE_RAYCAST_LAYER)
                colliderList.Add(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Structure")
        {
            if (other.GetComponent<Building>().type == needType)
                needTypeFlag = false;
            else
                colliderList.Remove(other);
        }
        else
        {
            if (other.gameObject.layer != layerGround && other.gameObject.layer != IGNORE_RAYCAST_LAYER)
                colliderList.Remove(other);
        }
    }

    public bool isBuildable()
    {
        if (needType == Building.Type.Normal)
            return colliderList.Count == 0;
        else
            return colliderList.Count == 0 && needTypeFlag;
    }

    public Vector3 getPosition()
    {
        return targetPosition;
    }

    public bool isNeeded()
    {
        return needType != Building.Type.Normal;
    }
}
