using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody rigidbody;


    // Use this for initialization
    void Start () {

        rigidbody = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
        ProcessInput();
	}

    private void ProcessInput()
    {
        AudioSource audio = GetComponent<AudioSource>();

        //Controlling the rocket
        Thrust();
        Steering();

        //Audio
        PlayRocketSound(audio);
        StopRocketSound(audio);       
    }
    private void Thrust()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.AddRelativeForce(Vector3.up);
        }
    }
    private void Steering()
    {
        rigidbody.freezeRotation = true; // take manual control of rotation

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate((Vector3.forward * Time.deltaTime) * 250);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate((Vector3.back * Time.deltaTime) * 250);
        }

        rigidbody.freezeRotation = false; // take manual control of rotation
    }
    private static void PlayRocketSound(AudioSource audio)
    {
        if (!audio.isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                audio.Play();
            }
        }
    }
    private static void StopRocketSound(AudioSource audio)
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            audio.Stop();
        }
    }

}
