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
        SceneManager.LoadScene(scene);
    }

    public GameObject optionsMenu;
        public void Options()
    {
        MenuOff();
        optionsMenu.SetActive(true);
    }

    public GameObject creditsMenu;
    public void Credits()
    {
        MenuOff();
        creditsMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
    public GameObject mainMenu;
    public void MenuOff()
    {
        mainMenu.SetActive(false);
        return;
    }

    public void Return()
    {
        Debug.LogError("This does not return appropriately!");
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
