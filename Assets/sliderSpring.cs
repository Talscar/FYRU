using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class sliderSpring : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

    Slider thisSlider;
    bool interaction = false;
	// Use this for initialization
	void Start () {
        thisSlider = GetComponent<Slider>();
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        interaction = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        thisSlider.value = 0;
        interaction = false;
    }
	// Update is called once per frame
	//void Update () {
		
	//}
}
