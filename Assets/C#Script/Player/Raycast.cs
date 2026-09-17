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
        Debug.DrawRay(playerMove.nowcamera.transform.position, playerMove.nowcamera.transform.forward * Raycastlength, Color.red);
        if (Physics.Raycast(playerMove.nowcamera.transform.position, playerMove.nowcamera.transform.forward, out RaycastHit hit, Raycastlength))
        {
            if (hit.transform.tag != "Player" && hit.transform.tag == "block" && Input.GetMouseButtonUp(1) && playerEnventory.item == null)//ブロックをとる
            {
                ItemBlock itemBlock = hit.collider.GetComponent<ItemBlock>();

                if (itemBlock.isholding && itemBlock.holdingobject != null)
                {
                    Blockholder blockholder = itemBlock.holdingobject.GetComponent<Blockholder>();
                    playerEnventory.Getitem(blockholder.holditem);
                    blockholder.holditem = null;
                    Debug.Log(blockholder.holditem);
                    itemBlock.holdingobject = null;
                    itemBlock.isholding = false;
                    //Debug.Log(playerEnventory.item.layer);
                    playerEnventory.item.layer = 2;
                }
                else
                {
                    playerEnventory.Getitem(hit.transform.gameObject);
                    itemBlock.holdingobject = null;
                    itemBlock.isholding = false;
                    //Debug.Log(playerEnventory.item.layer);
                    playerEnventory.item.layer = 2;
                }

            }
            else
                if (hit.transform.tag == "blockholder" && Input.GetMouseButtonUp(0) && playerEnventory.item != null && hit.transform.tag != "block")//ブロックを置く
                {
                    Blockholder blockholder = hit.transform.GetComponent<Blockholder>();
                    if (blockholder.holditem == null)
                    {

                        //Debug.Log("itemhold");

                        blockholder.holditem = playerEnventory.item;
                        ItemBlock itemBlock = playerEnventory.item.GetComponent<ItemBlock>();
                        itemBlock.holdingobject = hit.transform.gameObject;
                        itemBlock.isholding = true;
                        playerEnventory.item.layer = 0;
                        playerEnventory.item = null;
                    }
                }
        }
    }
}
