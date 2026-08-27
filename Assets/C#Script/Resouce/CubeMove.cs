using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    public float movespeed;
    public int existencecount;
    public int deletetime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (existencecount >= deletetime)
        {
            Destroy(this.gameObject);
        }
        this.gameObject.transform.position += transform.rotation*transform.forward *movespeed* Time.deltaTime;
        existencecount+=1;
    }
}
