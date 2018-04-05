using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reference the Unity Analytics namespace
using UnityEngine.Analytics;



public class gameData : MonoBehaviour {

    //I want to know what controller the player will use.
    //I want to know what my score is accross all games!
    //I want to know my time remaining to beat the game!
    //movementManager.CustomControllers myControlScheme;

    //  Use this call for wherever a player triggers a custom event
    float playTime = 0;
    //Analytics.CustomEvent(string customEventName,
    //IDictionary<string, object> eventData);

    //  Use this call for wherever a player triggers a custom event

    ////////Analytics.PlayTime(string playTimeName,
    ////////IDictionary<int> eventData);


    ////////Analytics.PlayTime(0, new Dictionary<int, object>
    ////////    {
    ////////    {"User play time", playTime  }
    ////////    });

//  int totalPotions = 5;
//int totalCoins = 100;
//string weaponID = "Weapon_102";
//Analytics.CustomEvent("gameOver", new Dictionary<string, object>
//  {
//    { "potions", totalPotions },
//    { "coins", totalCoins },
//    { "activeWeapon", weaponID }
//  });

    public int myControlScheme = 0;
    [Tooltip("The scenes in which are either main menu or chapter completions requiring a score reset for the following chapter.")]
    public int[] scenesToResetScore = { 0 };
    public float score;

    private static gameData data;
    //public movementManager.CustomControllers;

    private void OnLevelWasLoaded(int level)
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        foreach (int scene in scenesToResetScore)
        {
            if(scene == level)
            {

                Debug.LogWarning("This scoreData is not recorded. The score data was lost but was: " + score);
                score = 0;
            }
        }
        Start();
    }
    // Use this for initialization
    private void Awake()
    {
                DontDestroyOnLoad(this);
        if(data == null)
        {
            data = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }

    void Start()
    {
        movementManager manager = FindObjectOfType<movementManager>();//
        if(manager != null)
        {
            manager.controllerUpdate(myControlScheme);
        }
        else
        {
            Debug.LogError("Did not find manager!");
        }
    }
    // Update is called once per frame
    //void Update () {

    //}
}
