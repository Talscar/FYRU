using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UniSlider : MonoBehaviour,  IPointerUpHandler, IPointerDownHandler {

    //Slider
    Vector2 position;
    public float limit;
    public Transform handle;

    //float rate = transform.position - handle.position;

	// Use this for initialization
	void Start () {
        //newPointer = GetComponent<PointerEventData>();

    }

    bool carryHandle = false;
    //Handle follows the mouse to the limit and then breaks.
    public void OnPointerDown(PointerEventData eventdata)
    {
        newPointer = eventdata;
        carryHandle = true;
        Debug.Log("eventdata: " + eventdata);
    }
    //public void OnPointer
    public void OnPointerUp(PointerEventData eventdata)
    {
        carryHandle = false;
        Debug.Log("eventdata: " + eventdata);
        handle.transform.position = transform.position;
    }

    PointerEventData newPointer;
    // Update is called once per frame
    void Update () {
		if(carryHandle)
        {
            handle.position = new Vector3(newPointer.position.x, newPointer.position.y, 0);
        }

	}
}
