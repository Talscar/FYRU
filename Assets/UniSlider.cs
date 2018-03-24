using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UniSlider : MonoBehaviour,  IPointerUpHandler, IPointerDownHandler {

    //Slider
    //Vector2 position;
    public float limit;
    public Transform handle;

    //public Vector2 minMaxValues = new Vector2(-1, 1);
    public float minMaxValue = 1f;
    public Vector2 value;
    //float rate = transform.position - handle.position;

	// Use this for initialization
	void Start () {
        //newPointer = GetComponent<PointerEventData>();
        //valuePerUnit = minMaxValue / limit;
    }

    bool carryHandle = false;
    //Handle follows the mouse to the limit and then breaks.
    public void OnPointerDown(PointerEventData eventdata)
    {
        newPointer = eventdata;
        carryHandle = true;
        //Debug.Log("eventdata: " + eventdata);
    }
    //public void OnPointer
    public void OnPointerUp(PointerEventData eventdata)
    {
        carryHandle = false;
        //Debug.Log("eventdata: " + eventdata);
        handle.transform.localPosition = new Vector3(0, 0, 0);//transform.position;
    }
    //public float valuePerUnit;

    PointerEventData newPointer;

    //public Vector2 c
    // Update is called once per frame
    void Update () {
		if(carryHandle)
        {
            Vector3 centerPosition = transform.position; //center of *black circle*
            Vector3 newPos = new Vector3(newPointer.position.x, newPointer.position.y, 0);
            float distance = Vector3.Distance(newPos, centerPosition);
            if (distance > limit) //If the distance is less than the radius, it is already within the circle.
            {
                Vector3 fromOriginToObject = newPos - centerPosition; //~GreenPosition~ - *BlackCenter*
                fromOriginToObject *= limit / distance; //Multiply by radius //Divide by Distance
                newPos = centerPosition + fromOriginToObject; //*BlackCenter* + all that Math
                distance = Vector3.Distance(newPos, centerPosition);
                //minMaxValues / distance;

            }

            handle.position = newPos; 
        }
        Debug.Log(handle.position.x + " : " + transform.position.x + " = " + (handle.position.x - transform.position.x));
        value = new Vector2((handle.position.x - transform.position.x), (handle.position.y - transform.position.y)).normalized * minMaxValue;// * minMaxValue;

    }
}
// Vector3 centerPosition = transform.localPosition; //center of *black circle*
//float distance = Vector3.Distance(newLocation, centerPosition);

// if (distance > radius) //If the distance is less than the radius, it is already within the circle.
// {
// Vector3 fromOriginToObject = newLocation - centerPosition; //~GreenPosition~ - *BlackCenter*
//fromOriginToObject *= radius / distance; //Multiply by radius //Divide by Distance
// newLocation = centerPosition + fromOriginToObject; //*BlackCenter* + all that Math
// }