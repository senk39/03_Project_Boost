using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    [SerializeField] float rcsThrust = 250f;
    [SerializeField] float upThrust = 550f;

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
            rigidbody.AddRelativeForce(Vector3.up * upThrust);
        }
    }
    private void Steering()
    {
        rigidbody.freezeRotation = true; // take manual control of rotation

        float rotationThisFrame = rcsThrust * Time.deltaTime;


        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
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
