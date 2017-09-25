using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{

    public Canvas MenuScreen;
    public Button MenuButton;

    // Use this for initialization
    void Start()
    {
        //Declare the buttons to generate the start up menu 
        MenuButton = MenuButton.GetComponent<Button>();
        MenuScreen = MenuScreen.GetComponent<Canvas>();

        //disable canvas
        MenuScreen.enabled = false;
    }

    public void MenuClick()
    {
        MenuScreen.enabled = true;
        MenuButton.enabled = false;
    }

    public void pressedNo()
    {
        MenuScreen.enabled = false;
        MenuButton.enabled = true;
    }


    public void pressedYes()
    {
        SceneManager.LoadScene("TitleScreen");
    }


    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }

    public void EndGame()
    {
        SceneManager.LoadScene("TitleScreen");
    }

}