using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movementManager : MonoBehaviour
{
    int currentSelection = 0;
    [SerializeField] public static int charSelection = 0;
    [SerializeField] private int CharacterClassesSelection;
    public controlClass[] CharacterClasses;
    [System.Serializable]
    public struct controlClass
    {
        public string name;
        public movementControllerForFarmYardRoundUp[] Controllers;
    }

    void charUpdate()
    {
        foreach(movementControllerForFarmYardRoundUp controller in CharacterClasses[charSelection].Controllers)
        {
            controller.inControl(false);
        }
        charSelection = currentSelection;
        foreach (movementControllerForFarmYardRoundUp controller in CharacterClasses[charSelection].Controllers)
        {
            controller.inControl(true);
        }

    }

    public float x;
    public float z;

    public Vector2 dir()
    {
        return new Vector2(x, z);
    }

    //Vector2
    // Use this for initialization
    void Start()
    {
        if(_controllers.Length != 0)
        {
            controllersExist = true;
        }
        charUpdate();
    }

    bool controllersExist = false;
    // Update is called once per frame
    void Update()
    {
        if(currentSelection != charSelection)
        {
            charUpdate();
        }
        if (!controllersExist)
        {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
        }
        else if(controllerInput < _controllers.Length)
        {
            if (_controllers[controllerInput].uniSlider == null)
            {
                x = _controllers[controllerInput].controlInputRotation.value;
                z = _controllers[controllerInput].controlInputForward.value;
            }
            else
            {
                x = _controllers[controllerInput].uniSlider.value.x;
                z = _controllers[controllerInput].uniSlider.value.y;
            }
        }
    }

    //public void springSlider(Slider thisSlider)
    //{
    //    if(thisSlider.inter)
    //    thisSlider.value = 0;
    //    return;
    //}

    /// 
    /// Controller variables.
    /// 

    public CustomControllers[] _controllers;
    float controllers_Length = 0;
    //[Range(0, controllers_Length)]
    public int controllerInput = 0;
    [System.Serializable] public struct CustomControllers
    {
        public UniSlider uniSlider;
        public Slider controlInputRotation;
        public Slider controlInputForward;
    }

}

