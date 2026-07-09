using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
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
        if (Input.GetKey(KeyCode.S))
        {
            transform.position+=transform.TransformDirection(Vector3.back*Movespeed*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position+=transform.TransformDirection(Vector3.left*Movespeed*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position+=transform.TransformDirection(Vector3.right*Movespeed*Time.deltaTime);
        }
        if (Grounded == true&&Input.GetKeyDown(KeyCode.Space))
        {
            Grounded=false;
            rb.AddForce(Vector3.up*Jumppower);
        }

        RotationX=transform.localEulerAngles.y+Input.GetAxis("Mouse X")*MousemovepowerX;

        RotationY+=Input.GetAxis("Mouse Y")*MousemovepowerY;
        RotationY=Mathf.Clamp(RotationY,MinimumY,MaximumY);

        VerRot.transform.localEulerAngles=new Vector3(-RotationY,0,0);
        HotRot.transform.localEulerAngles=new Vector3(0,RotationX,0);
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Grounded=true;
        }
    }
}
