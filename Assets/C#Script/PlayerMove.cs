using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Jumppower = 400;
    public float Movespeed = 10;
    public float ShiftMovespeed;
    [SerializeField]
    private bool Grounded;
    private Rigidbody rb;
    public float MousemovepowerX = 15f;
    public float MousemovepowerY = 15f;
    public float MinimumX = -360f;
    public float MaximumX = 360f;
    public float MinimumY = -60f;
    public float MaximumY = 60f;
    float RotationX = 0f;
    float RotationY = 0;
    public GameObject VerRot;
    public GameObject HotRot;
    public float gravity;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(0,0,Movespeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(0,0,Movespeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Movespeed,0,0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(-Movespeed,0,0);
        }
        if (Grounded == true && Input.GetKey(KeyCode.Space))
        {
            Grounded = false;
            rb.velocity = new Vector3(rb.velocity.y, Jumppower, rb.velocity.z);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        RotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * MousemovepowerX;

        RotationY += Input.GetAxis("Mouse Y") * MousemovepowerY;
        RotationY = Mathf.Clamp(RotationY, MinimumY, MaximumY);

        VerRot.transform.localEulerAngles = new Vector3(-RotationY, 0, 0);
        HotRot.transform.localEulerAngles = new Vector3(0, RotationX, 0);

    }
    void FixedUpdate()
    {
        if (rb.velocity.y < 30)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * gravity * Time.deltaTime;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Grounded = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Grounded = false;
        }
    }
}
