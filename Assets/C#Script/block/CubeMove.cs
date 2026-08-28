using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    public float movespeed;
    public int existencecount;
    public int deletetime;
    private GameObject player;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (existencecount >= deletetime)
        {
            Destroy(this.gameObject);
            player.GetComponent<PlayerEnventory>().watchingitem = null;
        }
        rb.velocity = transform.forward * movespeed;
        existencecount += 1;
        if (this.gameObject.transform.position.y >= -5)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            if (other.gameObject.tag == "block")
            {
                player.GetComponent<PlayerEnventory>().item = other.gameObject;
                Destroy(this.gameObject);
                Debug.Log("item get");
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            if (collision.gameObject.tag == "block")
            {
                player.GetComponent<PlayerEnventory>().item = collision.gameObject;
                Destroy(this.gameObject);
                Debug.Log("item get");
            }
        }
    }
}
