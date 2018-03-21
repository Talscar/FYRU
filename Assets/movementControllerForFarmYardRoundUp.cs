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
        //if(ai)
        rb = GetComponent<Rigidbody>();
        //inflicted.Initialize(this.gameObject);
    }

    public float forceFactor = 10f;
    public float speed = 10f;
    //float moveSpeed;
    void Update()
    {
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = (Input.GetAxis("Vertical") * Time.deltaTime * 3.0f) * speed;

        transform.Rotate(0, x, 0);
        //transform.Translate(0, 0, z);


        Vector3 moveDirection = new Vector3(0, 0, z);
        //rb.MovePosition(moveDirection * speed);//(Vector3.forward * (speed * z));
        //rb.AddForce(Vector3.forward * 1000);
        rb.velocity += transform.forward * (z * forceFactor);

        ////if (inflicted != null)
        ////{

        ////}
        //////////Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Jump"),Input.GetAxis("Vertical"));

        ////if (inflicted != null)
        ////{
        ////    inflicted.TriggerAbility();
        ////}
        //if(Input.GetKeyDown(KeyCode.Alpha4))
        //{
        //    inflicted.TriggerAbility();
        //    //inflicted.Initialize(this.gameObject);
        //}
        ////////transform.position += moveDirection;
        //////rb.AddForce(moveDirection * speed);

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