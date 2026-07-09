using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed = 2f;
    [SerializeField, Range(60f, 90f)]
    float maxAngle_Y = 80f;
    float mouse_X;
    float mouse_Y;
    public GameObject cameraAnchorObject;
    public GameObject cameraObject;
    private float offset_Y;
    public GameObject targetObject;
    public static bool cameraModeFirst = true;
    // Start is called before the first frame update
    void Start()
    {
        offset_Y = cameraAnchorObject.transform.position.y - targetObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            cameraModeFirst = !cameraModeFirst;
        }
        mouse_X = Input.GetAxis("Mouse X") * rotationSpeed;
        mouse_Y = Input.GetAxis("Mouse Y") * rotationSpeed;
        Vector3 targetback = targetObject.transform.forward * -1f;
        Vector3 targettocamera = (cameraObject.transform.position - targetObject.transform.position);
        Vector3 targetright = Vector3.Cross(targettocamera, targetback).normalized;
        if (targettocamera.y < 0)
        {
            targetright = -targetright;
        }

        float angle = Vector3.SignedAngle(targettocamera, targetback, targetright);
        if (cameraModeFirst == true)
        {
            cameraObject.transform.RotateAround(cameraAnchorObject.transform.position, Vector3.up, mouse_X);
            if (-mouse_Y > 0)
            {
                if (angle < maxAngle_Y - rotationSpeed)
                {
                    cameraObject.transform.RotateAround(cameraAnchorObject.transform.position, cameraObject.transform.right, -mouse_Y);
                }
            }
            else if (-mouse_Y < 0)
            {
                if (angle > -maxAngle_Y + rotationSpeed)
                {
                    cameraObject.transform.RotateAround(cameraAnchorObject.transform.position, cameraObject.transform.right, -mouse_Y);
                }
            }
        }
        else
        {
            if (Input.GetMouseButton(1))
            {
                cameraObject.transform.RotateAround(cameraAnchorObject.transform.position,Vector3.up,mouse_X);
                cameraObject.transform.RotateAround(cameraAnchorObject.transform.position,cameraObject.transform.right,-mouse_Y);
            }
        }
        cameraAnchorObject.transform.position=new Vector3(targetObject.transform.position.x,targetObject.transform.position.y+offset_Y,targetObject.transform.position.z);
    }
}
