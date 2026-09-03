using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public PlayerMove playerMove;
    public float Raycastlength;
    public PlayerEnventory playerEnventory;
    void Start()
    {

    }

    void Update()
    {
        Debug.DrawRay(playerMove.nowcamera.transform.position,playerMove.nowcamera.transform.forward*Raycastlength,Color.red);
        if (Physics.Raycast(playerMove.nowcamera.transform.position, playerMove.nowcamera.transform.forward, out RaycastHit hit, Raycastlength))
        {
            if (hit.transform.tag != "Player"&&hit.transform.tag=="block"&&Input.GetMouseButtonUp(1)&&playerEnventory.item==null)
            {
                playerEnventory.Getitem(hit.transform.gameObject);
                hit.rigidbody.isKinematic=false;
            }
            if (hit.transform.tag != "Player" &&hit.transform.tag==""&&Input.GetMouseButtonUp(0)&&playerEnventory.item!=null)
            {
                GameObject child =hit.transform.GetChild(1).gameObject;
                playerEnventory.item.transform.position=child.transform.position;
                playerEnventory.item.transform.rotation=child.transform.rotation;
                Rigidbody rb=playerEnventory.item.GetComponent<Rigidbody>();
                rb.isKinematic=true;
                playerEnventory.item=null;
            }
        }
    }
}
