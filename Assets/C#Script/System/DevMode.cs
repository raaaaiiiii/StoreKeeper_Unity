using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevMode : MonoBehaviour
{
    public GameObject player;
    public GameObject block;
    // Start is called before the first frame update
    void Start()
    {
        block =(GameObject)Resources.Load("unity block");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F5)&&Input.GetKey(KeyCode.B))
        {
            //Vector3 instanceposition=
            //GameObject instance=(GameObject)Instantiate(block,player.transform.InverseTransformPoint()+=new Vector3(0f,2f,2f)))
        }
    }
}
