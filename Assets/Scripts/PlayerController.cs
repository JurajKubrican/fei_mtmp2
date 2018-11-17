using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{


    public float speed = 24;
    public bool primary = true;
    private Rigidbody rb;
    private GameObject player;
    private Vector3 initialOffset;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        initialOffset = rb.transform.position - player.transform.position;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.tag == "Player")
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.AddForce(movement * speed);
        }else{
            Vector3 position = player.transform.position;
            Debug.Log(position);
            position.x = - position.x;
            position.z = - position.z;
            Debug.Log(position);
            Quaternion rotation = player.transform.rotation;
            rb.transform.SetPositionAndRotation(position - initialOffset, rotation);
        }   
        
    }


    private void OnTriggerEnter(Collider other)
    {



    }
}
