using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movementManager : MonoBehaviour
{
    public int currentSelection = 0;
    [SerializeField] public static int charSelection = 0;
    //[SerializeField] private int CharacterClassesSelection;
    public controlClass[] CharacterClasses;
    [System.Serializable]
    public struct controlClass
    {
        public string name;
        public movementControllerForFarmYardRoundUp[] Controllers;
    }

    void characterUpdate()
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
        if (_controllers.Length != 0)
        {
            controllersExist = true;
            current = _controllers[controllerInput].control_Type;
            foreach (CustomControllers controller in _controllers)
            {
                controller.canvas.SetActive(false);//.activeSelf = false;
                //con
            }
            _controllers[controllerInput].canvas.SetActive(true);
            update_Controller_Function();
        }

        data = GameObject.FindObjectOfType<gameData>();
        if(data != null)
        {
            Debug.Log("DATA EXISTS!");
        }
        else
        {
            Debug.LogError("Does not...");
        }
        characterUpdate();
    }

    bool controllersExist = false;

    public void changePlayscheme(int pageZero)
    {
        if (pageZero < 0)
        {
            if (controllerInput <= 0)
            {
                //_controllers.Length 
                controllerInput = _controllers.Length + pageZero;
            }
            else
            {
                controllerInput += pageZero;
            }
        }
        else
        {
            if (controllerInput < _controllers.Length - 1 && controllerInput != _controllers.Length - 1)
            {
                controllerInput += pageZero;
            }
            else
            {
                controllerInput = 0;
            }
        }
        
        if(data != null)
        {
            data.myControlScheme = controllerInput;
        }
        return;
    }
    gameData data;
    public void controllerUpdate(int scheme)
    {
        controllerInput = scheme;
    }
    // Update is called once per frame
    void Update()
    {
        if(currentSelection != charSelection)
        {
            characterUpdate();
        }
        if (!controllersExist)
        {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
        }
        else if(controllerInput < _controllers.Length)
        {
            if(_controllers[controllerInput].control_Type != current)
            {
                //_controllers[controllerInput].canvas.SetActive(false);
                Debug.LogError("Dissable;");
                foreach (CustomControllers controller in _controllers)
                {
                    controller.canvas.SetActive(false);//.activeSelf = false;
                                                       //con
                }
                //_controllers[controllerInput].canvas.SetActive(false);
                if (!_controllers[controllerInput].canvas.activeInHierarchy)
                {
                    current = _controllers[controllerInput].control_Type;
                    _controllers[controllerInput].canvas.SetActive(true);
                    update_Controller_Function();
                }

            }
            if (callFunction != "")
            {
                Invoke(callFunction, 0);
            }
                //MonoBehaviour.//Invoke(call);
            ////////////////if (_controllers[controllerInput].uniSlider == null)
            ////////////////{
            ////////////////    x = _controllers[controllerInput].controlInputRotation.value;
            ////////////////    z = _controllers[controllerInput].controlInputForward.value;
            ////////////////}
            ////////////////else
            ////////////////{
            ////////////////    x = _controllers[controllerInput].uniSlider.value.x;
            ////////////////    z = _controllers[controllerInput].uniSlider.value.y;
            ////////////////}
        }
    }


    [SerializeField]private string callFunction = "";
    void update_Controller_Function()
    {
        Debug.Log("Check: " + callFunction);
        switch (current)
        {
            case controlMode.joystick_Direct:
                callFunction = "controller_Joystick_Direct";
                break;
            case controlMode.joystick_Look_With_Thrust:
                callFunction = "controller_Joystick_Look_With_Thrust";
                break;
            case controlMode.joystick_Selection:
                callFunction = "controller_Joystick_Selection";
                break;
            case controlMode.Sliders:
                callFunction = "controller_Sliders";
                break;
        }
        return;
    }

    void controller_Joystick_Direct()
    {
        x = _controllers[controllerInput].uniSlider.value.x;
        z = _controllers[controllerInput].uniSlider.value.y;
        //x = _controllers[controllerInput].controlInputRotation.value;
        //z = _controllers[controllerInput].controlInputForward.value;
        return;
    }
    void controller_Joystick_Selection()
    {

        return;
    }
    void controller_Joystick_Look_With_Thrust()
    {

        return;
    }
    void controller_Sliders()
    {
        x = _controllers[controllerInput].controlInputRotation.value;
        z = _controllers[controllerInput].controlInputForward.value;
        return;
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
        public GameObject canvas;
        public controlMode control_Type;

        public UniSlider uniSlider;
        public Slider controlInputRotation;
        public Slider controlInputForward;

    }
    public enum controlMode {joystick_Direct, joystick_Selection, joystick_Look_With_Thrust, Sliders };
    controlMode current;
}

