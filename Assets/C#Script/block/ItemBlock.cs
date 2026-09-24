using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBlock : MonoBehaviour
{
    public GameObject holdingobject=null;
    public bool isholding=false;
    public Vector3 startscale;
    public ItemType type;
    // Start is called before the first frame update
    void Start()
    {
        startscale=gameObject.transform.localScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.y <= -15)
        {
            Destroy(this.gameObject);
        }
        if (type == ItemType.food)
        {
            Renderer renderer=GetComponent<Renderer>();
            renderer.material.color=Color.blue;
        }
        if (type == ItemType.nofood)
        {
            Renderer renderer=GetComponent<Renderer>();
            renderer.material.color=Color.red;
        }
    }
    void Playercarry()
    {
        
    }
}
