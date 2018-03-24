using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveUpdate : MonoBehaviour {

    movementControllerForFarmYardRoundUp[] theseControllers;
    // Use this for initialization
    [SerializeField] private int count;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pig" || other.gameObject.tag == "Sheep" || other.gameObject.tag == "Cow" || other.gameObject.tag == "Chook")
        {
            count++;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Pig" || other.gameObject.tag == "Sheep" || other.gameObject.tag == "Cow" || other.gameObject.tag == "Chook")
        {
            count--;
        }
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
