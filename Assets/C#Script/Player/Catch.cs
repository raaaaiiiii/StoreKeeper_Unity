using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Catch : MonoBehaviour
{
    public new GameObject camera;
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject instance = (GameObject)Instantiate(cube, new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z),camera.transform.rotation);
    }
}
