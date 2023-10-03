using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuildManager : MonoBehaviour
{
    private bool isPreviewActivated = false; // 미리 보기 활성화 상태
    private GameObject Preview; // 미리 보기 프리팹을 담을 변수
    private GameObject Prefab; // 실제 생성될 프리팹을 담을 변수 
    private bool CanBulid;
    [SerializeField]
    private Dictionary<string, GameObject> structure;

    [SerializeField]
    private Transform tf_Player;  // 플레이어 위치

    private RaycastHit hitInfo;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private float range;

    public static BuildManager I;

    protected void Awake()
    {
        if (I == null)
        {
            I = this;
        }

        if (I != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        structure = new Dictionary<string, GameObject>();

        foreach (GameObject gameObject in Resources.LoadAll<GameObject>("Prefabs/Structure"))
        {
            structure.Add(gameObject.name, gameObject);
        }
    }
    public void OnBuildInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (!CanBulid)
            {
                CanBulid = true;
                UIManager.instance.Bulid();
            }
            else
            {
                CanBulid = false;
                Cancel();
                UIManager.instance.Bulid();
            }
                
           
        }
    }
    public void PreviewActive(string _structureName)
    {
        Preview = Instantiate(structure[_structureName + "_Preview"], tf_Player.position + tf_Player.forward, Quaternion.identity);
        Prefab = structure[_structureName];
        isPreviewActivated = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0) && !isPreviewActivated && CanBulid)
            PreviewActive("Floor");

        if (Input.GetKeyDown(KeyCode.Keypad1) && !isPreviewActivated && CanBulid)
            PreviewActive("Wall");
		if (Input.GetKeyDown(KeyCode.Keypad2) && !isPreviewActivated && CanBulid)
            PreviewActive("Fence");
        if (Input.GetKeyDown(KeyCode.Escape) && isPreviewActivated && CanBulid)
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

                if (hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("Structure"))
                {
                    if (Preview.GetComponent<PreviewObject>().isNeeded())
                    {
                        if (Preview.GetComponent<PreviewObject>().isBuildable())
                        {
                            Vector3 vector = Preview.GetComponent<PreviewObject>().getPosition();
                            Vector3[] vectors = Preview.GetComponent<PreviewObject>().getPositions();

                            float min = float.MaxValue;
                            Vector3 v;
                            int index = 0;

                            for (int i = 0; i < vectors.Length; i++)
                            {
                                v = vector + vectors[i];
                                float dist = Vector3.Distance(_location, v);

                                if (min > dist)
                                {
                                    index = i;
                                    Preview.transform.rotation = Quaternion.Euler(0, i * 90f, 0);
                                    min = dist;
                                }
                            }

                            _location = vector + vectors[index];
                        }
                    }
                }

                float x = _location.x;
                float y = _location.y + Preview.GetComponent<PreviewObject>().height;
                float z = _location.z;

                _location.Set(Mathf.Round(x * 0.5f) / 0.5f, Mathf.Round(y / 0.1f) * 0.1f, Mathf.Round(z * 0.5f) / 0.5f);


                Preview.transform.position = _location;
            }
        }
    }

    public void Build()
    {
        if (isPreviewActivated && Preview.GetComponent<PreviewObject>().isBuildable())
        {
            Instantiate(Prefab, Preview.transform.position, Preview.transform.rotation);
            Destroy(Preview);
            isPreviewActivated = false;
            Preview = null;
            Prefab = null;
        }
    }

    public void Cancel()
    {
        if (isPreviewActivated)
            Destroy(Preview);

        isPreviewActivated = false;

        Preview = null;
        Prefab = null;

    }
}
