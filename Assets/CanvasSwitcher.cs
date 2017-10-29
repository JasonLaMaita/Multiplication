using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSwitcher : MonoBehaviour {

    public GameObject canvasLandscape;
    public GameObject canvasPortrait;


	// Use this for initialization
	void Start () {
		if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            canvasLandscape.GetComponent<Canvas>().enabled = true;
            canvasPortrait.GetComponent<Canvas>().enabled = false;
        }
        else
        {
            canvasLandscape.GetComponent<Canvas>().enabled = false;
            canvasPortrait.GetComponent<Canvas>().enabled = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            canvasLandscape.GetComponent<Canvas>().enabled = true;
            canvasPortrait.GetComponent<Canvas>().enabled = false;
        }
        else
        {
            canvasLandscape.GetComponent<Canvas>().enabled = false;
            canvasPortrait.GetComponent<Canvas>().enabled = true;
        }
    }
}
