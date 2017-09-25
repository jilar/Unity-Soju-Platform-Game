using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class instructions : MonoBehaviour {

    public Canvas InstructionScreen;
    public Button InstructionButton;
    public Text mytext = null;
    public Text Titletext = null;
    public int counter = 0;

    // Use this for initialization
    void Start()
    {
        //Declare the buttons to generate the start up menu 
        InstructionButton = InstructionButton.GetComponent<Button>();
        InstructionScreen = InstructionScreen.GetComponent<Canvas>();

        //disable canvas
        InstructionScreen.enabled = false;
    }

    public void changeText()
    {
        
      

        counter++;
        if (counter % 2 == 1)
        {
            InstructionScreen.enabled = true;
            Titletext.text = "Instructions:";
            mytext.text = "Make it to the last platform to win! Move left with A and move right with D. Double clicking W teleports you to a further plattform (from camera) while double clicking S teleports you closer. Silver coins are worth 100 points while gold coins are worth 500. Touching a fish or getting hit by a cannon loses a life.";
        }
        else
        {
            InstructionScreen.enabled = false;
            Titletext.text = "";
            mytext.text = "";
        }
    }
}
