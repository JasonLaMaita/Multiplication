using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
    int score = 0; // the integer value of the score on screen
    [Header("Landscape Variables")]
    public GameObject scoreVarLandscape1; // the first digit for the score in landscape mode
    public GameObject scoreVarLandscape2;//the second digit for the score in landscape mode

    [Header("Portrait Variables")]
    public GameObject scoreVarPortrait1; //  the first digit for the score in portrait mode
    public GameObject scoreVarPortrait2; //  the second digit for the score in portrait mode

    [Header("Score Values")]
    int scoreValue1;
    int scoreValue2;

	// Use this for initialization
	
    /**
     * increase the score by one, and set the sprites on the number objects accordingly
     */ 
    public void increaseScore()
    {
        score++;
        scoreValue1 = score / 10 % 10;
        scoreValue2 = score % 10;
        scoreVarLandscape1.GetComponent<Number>().setIndex(scoreValue1);
        scoreVarLandscape2.GetComponent<Number>().setIndex(scoreValue2);
        scoreVarPortrait1.GetComponent<Number>().setIndex(scoreValue1);
        scoreVarPortrait2.GetComponent<Number>().setIndex(scoreValue2);
    }
}
