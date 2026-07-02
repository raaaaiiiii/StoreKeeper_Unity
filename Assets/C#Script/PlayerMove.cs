using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float Jumppower=400;
    [SerializeField]
    private float Movespeed=10;
    private bool Grounded;
    private Rigidbody rb;
    public float MousemovepowerX=15f;
    public float MousemovepowerY=15f;
    public float MinimumX=-360f;
    public float MaximumX=360f;
    public float MinimumY=-60f;
    public float MaximumY=60f;
    float RotationX=0f;
    float RotationY=0;
    public GameObject VerRot;
    public GameObject HotRot;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position+=transform.TransformDirection(Vector3.forward*Movespeed*Time.deltaTime);
        }
        
    }
}
