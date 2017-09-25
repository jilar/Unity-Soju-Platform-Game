using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartUpMenuScript : MonoBehaviour {

    public Canvas quit;
    public Button play;
    public Button exit;

	// Use this for initialization
	void Start () 
    {
        //Declare the buttons to generate the start up menu 
        exit = exit.GetComponent<Button>();
        quit = quit.GetComponent<Canvas>();
        play = play.GetComponent<Button>();

        //disable canvas
        quit.enabled = false; 	
	}

    public void pressedNo()
    {
        quit.enabled = false;
        exit.enabled = true;
        play.enabled = true;
    }

    //Exit the menu
    public void Exit()
    {
        quit.enabled = true;
        exit.enabled = false;
        play.enabled = false;
    }
	
    public void StartLevel()
    {
        SceneManager.LoadScene("main");
    }

    public void exitMyGame()
    {
        Application.Quit();
    }
}
