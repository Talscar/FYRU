using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;// Versions;
public class ObjectiveManager : MonoBehaviour {

    /// 
    /// For each objective that requires a set ammount of animals to arrive.
    /// Object.add 1 animal count if that animal is of the desired animals to be in the pen.
    /// Once this object is completed, if a bool for gate closure on arrival is marked, close the gate and disconnect these controllers from
    /// the players control.
    /// 
    /// else keep connected and make player get all animals into all seperate pens.
    ///


        //public ObjectiveUpdate[] 
    //public objective_Orientation[] objectives;
    [System.Serializable]public struct objective_Orientation
    {
        public bool doesGateClosureOnArrival;
        public string tag_Type;
        public int TotalToCount;
        //public int current;
        public bool meetsCriteria;
        public movementControllerForFarmYardRoundUp[] controllers;
    }
    /// Objective[]
    ///     - Int count;
    ///     - Int current;
    ///     - controllers[] animal; **Note: Animals need the reference to disconncet from the desired array incase they are no longer connected.**
    /// 

    public void ObjectiveCheck()
    {
        int i = 0;
        foreach(ObjectiveUpdate obj in _objectives)
        {
            if(obj.myObjective.meetsCriteria)
            {
                i++;
            }
        }
        if(i >= _objectives.Length)
        {
            Debug.LogError("Loading level");
            //levelComplete();
            nextLevel();
        }
        Debug.Log("The count was: " + i + " | And the length is: " + _objectives.Length);
    }



    public ObjectiveUpdate[] _objectives;
    public void OnEnable()
    {
        int length = 0;
        //ObjectiveUpdate[] __objectives = FindObjectsOfType<ObjectiveUpdate>();//(ObjectiveUpdate)FindObjectsOfType(typeof(ObjectiveUpdate))//FindObjectsOfType<ObjectiveUpdate>();
        _objectives = FindObjectsOfType<ObjectiveUpdate>(); //__objectives;
        Debug.LogError("Loaded objectives.");
        //length = _objectives.Length;
        //objectives = new objective_Orientation[length];
        //int i = 0;
        //foreach (ObjectiveUpdate obj in _objectives)
        //{
        //    //objectives[i] = obj.myObjective;
        //    i++;
        //}
        Debug.Log("Successfully loaded objectives on scene Load!");
    }
    public void load_Objectives(objective_Orientation[] new_Objectives)
    {
        //objectives = new_Objectives;
    }
    public void save_Score()
    {

    }
    public float startTime = 30f;
    bool gamePlaying = false;
    [SerializeField] private float timeRemaining = 0f;
    public Time thisTime;
	// Use this for initialization
	void Start () {
        timeRemaining += startTime;
        gamePlaying = true;
	}

    // Update is called once per frame
    public UnityEngine.UI.Text timerText;
	void Update () {
        if (gamePlaying)
        {
            timeRemaining -= Time.deltaTime;
        }
        if (timerText != null)
            timerText.text = "" + (int)timeRemaining;

        if (timeRemaining < 0 && gamePlaying)

        {
            gamePlaying = false;
            levelFailed();
        }
	}

    public int nextScene;
    void nextLevel()
    {
        SceneManager.LoadScene(nextScene);
        //Scene
    }
    void levelComplete()
    {

    }
    void levelFailed()
    {
            Debug.LogWarning("End level, You lost!");
        SceneManager.LoadScene(0);
    }
}
