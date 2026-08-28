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
        originalscale = getitem.transform.localScale;
        getitem.transform.localScale = originalscale / itemscale;
    }
    public void Throwitem()
    {
        if (item != null)
        {
            Rigidbody rb;
            rb = item.GetComponent<Rigidbody>();
            item.transform.localScale = originalscale;
            item = null;
            rb.velocity = transform.forward * throwpower;
        }
    }
}
