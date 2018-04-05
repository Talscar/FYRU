using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Collections.Generic;
using UnityEngine.Analytics;

public class GameAnalytics : MonoBehaviour
{
   //Variables
   public int totalPotions = 5;
   public int totalCoins = 100;
   public string weaponID = "Weapon_102";
    public void RecordAnalytics()
    {

        Analytics.CustomEvent("gameOver", new Dictionary<string, object>
      {
         { "potions", totalPotions },
         { "coins", totalCoins },
         { "activeWeapon", weaponID }
       });
    }
	// Use this for initialization
	//void Start () {
		
	//}
	
	//// Update is called once per frame
	//void Update () {
		
	//}
}
