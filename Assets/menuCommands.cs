using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;// Versions;

public class menuCommands : MonoBehaviour {

    //Options menu
    //Credits menu
    //Return
    //Quit Application


    // Use this for initialization
    //void Start () {

    //}

    // Update is called once per frame
    //void Update () {

    //}
    public int mainMenuScene = 0;
    public void MainMenu()
    {
        //SceneManager.
        SceneManager.LoadScene(mainMenuScene);
        //Application.LoadLevel(mainMenuScene);
    }
    public void playGame(int scene)
    {

    }

    public GameObject optionsMenu;
        public void Options()
    {

    }

    public GameObject creditsMenu;
    public void Credits()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}
