using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveUpdate : MonoBehaviour {
    public ObjectiveManager.objective_Orientation myObjective;

   public movementControllerForFarmYardRoundUp[] theseControllers;
    // Use this for initialization
    [SerializeField] private int count;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pig" || other.gameObject.tag == "Sheep" || other.gameObject.tag == "Cow" || other.gameObject.tag == "Chook")
        {
            if(other.GetComponent("movementControllerForFarmYardRoundUp") != null)
            {
                count++;
                for(int i = 0; i < theseControllers.Length; i++)
                {
                    if(theseControllers[i] == null)
                    {
                        theseControllers[i] = other.GetComponent<movementControllerForFarmYardRoundUp>(); //SlotInObjective(count, false);
                        other.GetComponent<movementControllerForFarmYardRoundUp>().SlotInObjective(i, false);

                        break;
                    }
                }

                //theseControllers[count] = other.GetComponent<>
            }
            //count++;
        }
        if (myObjective.TotalToCount <= count)
        {
            myObjective.meetsCriteria = true;
            theManager.ObjectiveCheck();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Pig" || other.gameObject.tag == "Sheep" || other.gameObject.tag == "Cow" || other.gameObject.tag == "Chook")
        {
            if (other.GetComponent("movementControllerForFarmYardRoundUp") != null)
            {
                Debug.LogWarning("Game break when moving from within the play area!");
                int remove = other.GetComponent<movementControllerForFarmYardRoundUp>().SlotInObjective(0, true);
                theseControllers[remove] = null; //SlotInObjective(count, false);
                count--;
                //theseControllers[count] = other.GetComponent<>
            }
            //count--;
        }
        if (myObjective.TotalToCount > count)
        {
            myObjective.meetsCriteria = false;
        }
    }

    ObjectiveManager theManager;
    void Start () {
        theseControllers = new movementControllerForFarmYardRoundUp[myObjective.TotalToCount];
        theManager = FindObjectOfType<ObjectiveManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
