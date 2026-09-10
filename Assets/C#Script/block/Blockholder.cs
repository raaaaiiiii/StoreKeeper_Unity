using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockholder : MonoBehaviour
{
    public GameObject holdpoint = null;
    public GameObject holditem = null;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (holditem != null)
        {
            holditem.transform.position = holdpoint.transform.position;
            holditem.transform.rotation = holdpoint.transform.rotation;
        }
    }
}
