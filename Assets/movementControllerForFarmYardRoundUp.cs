using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementControllerForFarmYardRoundUp : MonoBehaviour {

    //I am the controller... but no one can just control me.
    //I am given a controller at start by the game manager or if a player drops off the service I can be given a AI in it's place.
    //While I am told to do actions, I will move things based on what inputs I have been given.
    //Should no players be present the game will end according to the server rules.

    //Functions for movement
    //Controller/Gamepad/Touchpad/Mouse and Keyboard.

    //Function for my score

    //Function for my own interactions

    //Function to use Powerups in my possession.
    public bool identifier_IsAI = false;

    //public StatusEffect inflicted;

    Rigidbody rb;
    void Start()
    {
        globalManager = (movementManager)FindObjectOfType(typeof(movementManager));//GetComponent<movementManager>();
        //if(ai)
        rb = GetComponent<Rigidbody>();
        //inflicted.Initialize(this.gameObject);
    }

    public float forceFactor = 10f;
    public float speed = 10f;
    //float moveSpeed;
    void Update()
    {
        Vector2 dir = new Vector2();
        if(globalManager != null)
        {
            if(_inControl)
            {
                //Get a set of inputs
                dir = globalManager.dir();
            }
        }
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
        //var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        //var z = (Input.GetAxis("Vertical") * Time.deltaTime * 3.0f) * speed;
        //Vector2 dir(movementManager.);


        if (dir != new Vector2(0, 0))
        {
            transform.Rotate(0, dir.x, 0);

            Vector3 moveDirection = new Vector3(0, 0, dir.y);
            rb.velocity += transform.forward * (dir.y * forceFactor);
        }
    }



    movementManager globalManager;
    bool _inControl;
    public void inControl(bool isControlling)
    {
        _inControl = isControlling;
        return;
    }
    //public Ability[] statusEffect;

    //[System.Serializable]public struct statusModifier
    //{

    //}
    //public void moreThanOneEffect(StatusEffect[] effects)
    //{
    //    foreach(StatusEffect effect in effects)
    //    {
    //        inflicted = effect;
    //        statusProcessor(effect.Effect, effect);
    //    }
    //    return;
    //}
    //public void statusProcessor(StatusEffect.dataTypes data, Ability _this)
    //{
    //    switch(data)
    //    {
    //        case StatusEffect.dataTypes.scale:
    //            gameObject.transform.localScale = transform.localScale * inflicted.Scale.scalePercent;
    //            break;

    //        case StatusEffect.dataTypes.speed:
    //            speed = speed * inflicted.Speed.speedPercent;
    //            break;

    //        case StatusEffect.dataTypes.knockback:
    //            break;
    //    }
    //    Debug.Log("Processing the StatusEffect!");
    //    inflicted = null;

    //    return;
    //}
}

    //bool whileMovement;
    //void movement(bool moving)
    //{
    //    whileMovement = moving;
    //}


    //void Update()
    //{
    //    if(whileMovement)
    //    {
    //        //The player is moving

    //        //The player is moving
    //    }
    //}