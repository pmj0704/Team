using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float speed = 5f;

    private Rigidbody playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float xInput = Input.GetAxis("Horizontal"); 
        float zInput = Input.GetAxis("Vertical"); 

        float xspeed = xInput * speed;
        float zspeed = zInput * speed;

        Vector3 newVelocity = new Vector3(-xspeed, 0f, -zspeed);

        playerRigidbody.velocity = newVelocity;

        // มกวม
        if (Input.GetKey(KeyCode.Space) == true)
        {
            playerRigidbody.AddForce(0f, 25f, 0f);
        }
    }
}
