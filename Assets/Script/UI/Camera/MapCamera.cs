using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCamera : MonoBehaviour
{
    public GameObject Target;
    public GameObject map;
    private  float offsetX = 0.0f;           
    private float offsetY = 20.0f;
    private float offsetZ = 0.0f;         

    public float CameraSpeed = 10.0f;      
    Vector3 TargetPos;                     

    // Update is called once per frame
    void FixedUpdate()
    {
        TargetPos = new Vector3(
            Target.transform.position.x + offsetX,
            Target.transform.position.y + offsetY,
            Target.transform.position.z + offsetZ
            );
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);
    }
}
