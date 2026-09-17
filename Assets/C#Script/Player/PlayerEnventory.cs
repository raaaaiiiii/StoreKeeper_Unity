using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnventory : MonoBehaviour
{
    public GameObject item;
    public GameObject watchingitem;
    public GameObject holdpoint;
    public float itemscale;
    public Vector3 originalscale;
    public float throwpower;
    public new GameObject camera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (item != null)
        {
            item.transform.position = holdpoint.transform.position;
            item.transform.rotation = holdpoint.transform.rotation;
        }
    }
    public void Getitem(GameObject getitem)
    {
        item = getitem;
        ItemBlock itemBlock =item.transform.GetComponent<ItemBlock>();
        originalscale = itemBlock.startscale;
        getitem.transform.localScale = originalscale / itemscale;
    }
    public void Throwitem()
    {
        if (item != null)
        {
            Rigidbody rb;
            rb = item.GetComponent<Rigidbody>();
            item.transform.localScale = originalscale;
            rb.velocity = Vector3.zero;
            item.transform.rotation=camera.transform.rotation;
            item.transform.position=holdpoint.transform.position;
            Vector3 force = transform.forward * throwpower + transform.up * throwpower/2;
            rb.AddForce(force, ForceMode.Impulse);
            //rb.velocity = item.transform.forward * throwpower;
            //rb.velocity = item.transform.up * throwpower;
            item.layer=0;
            item = null;
            
        }
    }
}
