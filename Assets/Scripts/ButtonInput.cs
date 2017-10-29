using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInput : MonoBehaviour {

    public int buttonIndex; //the number on the button, 10 for delete, 11 for enter
    public GameObject logicCube; // the gameobject doing most of the math and logic
	// Use this for initialization
	
    /**
     * used on the OnClicked Event for each of the buttons
     */
    public void clicked()
    {
        logicCube.GetComponent<mathProblems>().setAnswer(buttonIndex);
        GetComponent<AudioSource>().Play();
    }
}
