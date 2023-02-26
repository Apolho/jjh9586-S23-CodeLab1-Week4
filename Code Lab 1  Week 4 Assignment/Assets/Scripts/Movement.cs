using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb; 

    public float speed; //sets speed
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>(); //gets rigidbody component
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) //when A is pressed
        {
            rb.AddForce(Vector3.left * speed); //move left
        }

        if (Input.GetKey(KeyCode.D)) //when D is pressed
        {
            rb.AddForce(Vector3.right * speed); //move right
        }

        rb.velocity *= 0.99f; //will add drag so the game object stops moving.
    }
}
