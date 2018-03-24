using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour {

    /// 
    /// For each objective that requires a set ammount of animals to arrive.
    /// Object.add 1 animal count if that animal is of the desired animals to be in the pen.
    /// Once this object is completed, if a bool for gate closure on arrival is marked, close the gate and disconnect these controllers from
    /// the players control.
    /// 
    /// else keep connected and make player get all animals into all seperate pens.
    /// 
    /// Objective[]
    ///     - Int count;
    ///     - Int current;
    ///     - controllers[] animal; **Note: Animals need the reference to disconncet from the desired array incase they are no longer connected.**
    /// 

    public objective_Orientation[] objectives;
    [System.Serializable]public struct objective_Orientation
    {
        public bool doesGateClosureOnArrival;
        public int count;
        public int current;
        public movementControllerForFarmYardRoundUp[] controllers;
    }

    public void load_Objectives(objective_Orientation[] new_Objectives)
    {
        objectives = new_Objectives;
    }
    public void save_Score()
    {

    }
    public float startTime = 30f;
    bool gamePlaying = false;
    float timeRemaining = 0f;
    public Time thisTime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!gamePlaying)
            timeRemaining -= Time.deltaTime;

        if (timeRemaining < 0)

        {
            gamePlaying = false;
            Debug.LogWarning("End level, You lost!");
        }


	}
}
