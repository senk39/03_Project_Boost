using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{

    int currentScene = 0;
    bool isSteeringFreezed = false;

    enum CurrentStatus { Alive, Dying, Transcending};
    CurrentStatus currentStatus = CurrentStatus.Alive;

    [SerializeField] float rcsThrust = 250f;
    [SerializeField] float upThrust = 550f;
    [SerializeField] AudioClip mainEngine;


    Rigidbody rigidbody;
    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {

        rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
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

    //Controlling the rocket
    private void Thrust()
    {
        if (Input.GetKey(KeyCode.W) && (isSteeringFreezed == false))
        {
            rigidbody.AddRelativeForce(Vector3.up * upThrust);
            
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
        }
        else
        {
            audioSource.Stop();
        
        }

    }
    private void Steering()
    {
        rigidbody.freezeRotation = true; // take manual control of rotation

        float rotationThisFrame = rcsThrust * Time.deltaTime;


        if (Input.GetKey(KeyCode.A) && (isSteeringFreezed == false))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D) && (isSteeringFreezed == false))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }

        rigidbody.freezeRotation = false; // take manual control of rotation
    }
    
    //Audio
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

    //Collision
    void OnCollisionEnter(Collision collision)
    {
        if(currentStatus != CurrentStatus.Alive)
        {
            return;
        }
        else if(collision.gameObject.tag == "Friendly")
        {
            return;
        }

        else if (collision.gameObject.tag == "Finish")
        {
            isSteeringFreezed = true;
            currentStatus = CurrentStatus.Transcending;
            print("CONGRATS!");
            Invoke("LoadNextLevel", 1f);
        }
        else // literally Sayori
        {
            isSteeringFreezed = true;
            currentStatus = CurrentStatus.Dying;
            print("aua :(");
            Invoke("RepeatLevel", 1f);
        }
    }

    //Load Level
    void LoadNextLevel()
    {
        isSteeringFreezed = false;
        currentScene++;
        SceneManager.LoadScene(currentScene);
    }

    void RepeatLevel()
    {
        isSteeringFreezed = false;

        SceneManager.LoadScene(currentScene);
    }
}
