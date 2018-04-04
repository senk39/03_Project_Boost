using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody rigidbody;

    // Use this for initialization
    void Start () {

        rigidbody = GetComponent<Rigidbody>();
       // transform = GetComponent<Transform>();
		
	}
	
	// Update is called once per frame
	void Update () {

        ProcessInput();
		
	}

    private void ProcessInput()
    {
        //DO PRZODU
        if(Input.GetKey(KeyCode.W))
        {
            rigidbody.AddRelativeForce(Vector3.up);
        }
        //BOKI 
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate((Vector3.forward * Time.deltaTime ) * 250);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate((Vector3.back * Time.deltaTime ) * 250);
        }
    }
}
