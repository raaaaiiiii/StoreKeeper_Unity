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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F3)&&Input.GetKeyDown(KeyCode.B))
        {
            Vector3 instanceposition= player.transform.localPosition+=new Vector3(2f,2f,0f);
            GameObject instance=(GameObject)Instantiate(block,new Vector3(instanceposition.x,instanceposition.y,instanceposition.z),Quaternion.identity);
        }
    }
}
