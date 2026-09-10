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
                ItemBlock itemBlock =hit.collider.GetComponent<ItemBlock>();
                Blockholder blockholder=itemBlock.holdingobject.GetComponent<Blockholder>();
                if (itemBlock.isholding)
                {
                    playerEnventory.Getitem(blockholder.holditem);
                    blockholder.holditem=null;
                    itemBlock.holdingobject=null;
                    itemBlock.isholding=false;
                }
                else
                {
                    playerEnventory.Getitem(hit.transform.gameObject);
                    itemBlock.holdingobject=null;
                    itemBlock.isholding=false;
                }
                
            }
            if (hit.transform.tag != "Player" &&hit.transform.tag=="blockholder"&&Input.GetMouseButtonUp(0)&&playerEnventory.item!=null)
            {
                Blockholder blockholder =hit.collider.GetComponent<Blockholder>();
                blockholder.holditem=playerEnventory.item;
                ItemBlock itemBlock =playerEnventory.item.GetComponent<ItemBlock>();
                itemBlock.holdingobject=hit.transform.gameObject;
                playerEnventory.item=null;
            }
        }
    }
}
