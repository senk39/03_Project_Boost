using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class Oscillator : MonoBehaviour {

    [SerializeField]
    Vector3 movementVector;
    [Range(0,1)]
    [SerializeField]
    float movementFactor;

    //Vector3 startingPos = (0.0f, 0.0f, 0.0f); TODO


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
