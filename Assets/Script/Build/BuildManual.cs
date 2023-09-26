using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Craft
{
    public string craftName; // 이름
    public GameObject prefab; // 실제 설치 될 프리팹
    public GameObject PreviewPrefab; // 미리 보기 프리팹
}

public class BuildManual : MonoBehaviour
{
    private bool isActivated = false;  // CraftManual UI 활성 상태
    private bool isPreviewActivated = false; // 미리 보기 활성화 상태

    private GameObject Preview; // 미리 보기 프리팹을 담을 변수
    private GameObject Prefab; // 실제 생성될 프리팹을 담을 변수 

    [SerializeField]
    private Craft[] craft_floor;

    [SerializeField]
    private Transform tf_Player;  // 플레이어 위치

    private RaycastHit hitInfo;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private float range;

    public void SlotClick(int _slotNumber)
    {
        Debug.Log("Slot Clit" + _slotNumber);
        Preview = Instantiate(craft_floor[_slotNumber].PreviewPrefab, tf_Player.position + tf_Player.forward, Quaternion.identity);
        Prefab = craft_floor[_slotNumber].prefab;
        isPreviewActivated = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0) && !isPreviewActivated)
            SlotClick(0);

        if (Input.GetKeyDown(KeyCode.Keypad1) && !isPreviewActivated)
            SlotClick(1);

        if (Input.GetKeyDown(KeyCode.Escape) && isPreviewActivated)
            Cancel();

        if (isPreviewActivated)
            PreviewPositionUpdate();

        if (Input.GetButtonDown("Fire1"))
            Build();
    }

    private void PreviewPositionUpdate()
    {
        if (Physics.Raycast(tf_Player.position, tf_Player.forward, out hitInfo, range, layerMask))
        {
            if (hitInfo.transform != null)
            {
                Vector3 _location = hitInfo.point;

                if (Preview.GetComponent<PreviewObject>().isRotatable)
                {
                    if (Input.GetKeyDown(KeyCode.Q))
                        Preview.transform.Rotate(0f, -90f, 0f);
                    if (Input.GetKeyDown(KeyCode.E))
                        Preview.transform.Rotate(0f, +90f, 0f);
                }

                if (Preview.GetComponent<PreviewObject>().isNeeded())
                {
                    _location = Preview.GetComponent<PreviewObject>().getPosition();
                }
                else
                {
                    _location.Set(Mathf.Round(_location.x), Mathf.Round(_location.y / 0.1f) * 0.1f, Mathf.Round(_location.z));
                }


                Preview.transform.position = _location;

            }
        }
    }

    private void Build()
    {
        if (isPreviewActivated && Preview.GetComponent<PreviewObject>().isBuildable())
        {
            Instantiate(Prefab, Preview.transform.position, Preview.transform.rotation);
            Destroy(Preview);
            isActivated = false;
            isPreviewActivated = false;
            Preview = null;
            Prefab = null;
        }
    }

    private void Cancel()
    {
        if (isPreviewActivated)
            Destroy(Preview);

        isActivated = false;
        isPreviewActivated = false;

        Preview = null;
        Prefab = null;
    }
}
