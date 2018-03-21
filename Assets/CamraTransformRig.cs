using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamraTransformRig : MonoBehaviour {
    public Transform followThis;
    public Vector3 vectorTransform;
    public Vector3 vectorRotation;
    public float drag;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Follow the transform and maintain a certain speed.
        if (followThis != null)
        {
            transform.position = followThis.position + vectorTransform;
            //Quaternion rotation = Quaternion.LookRotation(followThis.position);
            //transform.rotation = rotation;
            //transform.rotation = 
        }
		
	}
}
