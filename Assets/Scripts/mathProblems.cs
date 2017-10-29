using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mathProblems : MonoBehaviour {

    
    [Header("Landscape Variables")]
    public GameObject var1Landscape; // sprite for digit 1 of problem in landscape mode.
    public GameObject var2Landscape; // sprite for digit 2 of problem in landscape mode
    public GameObject answerVar1Landscape;//sprite for digit 1 of the answer in landscape mode
    public GameObject answerVar2Landscape;//sprite for digit 2 of the answer in landscape mode

    [Header("Portrait Variables")]
    public GameObject var1Portrait; // sprite for digit 1 of problem. in portrait mode
    public GameObject var2Portrait; // sprite for digit 2 of problem in portrait mode
    public GameObject answerVar1Portrait;//sprite for digit 1 of the answer in portrait mode
    public GameObject answerVar2Portrait;//sprite for digit 2 of the answer in portrait mode

    private int answerIndex = 0;//current digit of the number are you inputting?
    //private int answerLimit = 2;
    private int answer;//the players answer to the problem
    private int result;//the real result to the problem

    [Header("SoundFX")]
    public AudioClip audioCorrect;// sound to play when correct answer
    public AudioClip audioWrong;// sound to play when wrong answer

	// Use this for initialization
	void Start () {
        makeProblem();
  
	}

	// Update is called once per frame
	void Update () {
		
	}

    /**
     * Sets the two variables for the math problem to random numbers
     * 
     */
    public void makeProblem()
    {
        int random1 = Random.Range(0, 9);
        int random2 = Random.Range(0, 9);
        setValue(var1Landscape,random1);
        setValue(var2Landscape, random2);
        setValue(var1Portrait, random1);
        setValue(var2Portrait, random2);
    }
    /**
     * takes the value of the button that was pressed and passes it to the two answer variables
     * 
     * @param value the number on the button that was pressed
     * 
     */
    public void setAnswer(int value)
    {

        if (value < 10)
        {
          
            if (answerIndex == 0)
            {
                setValue(answerVar2Landscape, value);
                setValue(answerVar2Portrait, value);
                answerIndex++;
            }
            else
            {
                swapNumbers();
                setValue(answerVar2Landscape, value);
                setValue(answerVar2Portrait, value);

            }
           
        }
       
        else if (value == 11)
        {
            //ENTER
            checkAnswer();
        }
        else
        {
            resetNumbers();
        }
    }

    /**
     * when the second variable is being input, the first needs to move to the left
     */
    void swapNumbers()
    {
        setValue(answerVar1Landscape, getValue(answerVar2Landscape));
        setValue(answerVar1Portrait, getValue(answerVar2Portrait));

    }

    /**
     * sets the answer variables back to 0 and sets the cursor to the one on the right
     */
    void resetNumbers()
    {
        setValue(answerVar1Landscape, 0);
        setValue(answerVar2Landscape, 0);
        setValue(answerVar1Portrait, 0);
        setValue(answerVar2Portrait, 0);
        answerIndex = 0;
    }

    /**
     * sets the value of a number object, in the number class, and sets its sprite accordingly
     * 
     * @param number the variable on the screen for the equation
     * @param value the new integer value for the number object
     * 
     */
    public void setValue(GameObject number, int value)
    {
        number.GetComponent<Number>().setIndex(value);
    }

    /**
     * gets the integer value of the number object
     * 
     * @param number  the number object to find the value of
     * @return the integer value
     */
    public int getValue(GameObject number)
    {
        return number.GetComponent<Number>().getIndex();
    }

    /**
     * sets the two number objects to one integer value, and checks if it is correct. 
     * If it is, make a new problem, and reset the answer number objects
     */
    public void checkAnswer()
    {
        string temp = (getValue(answerVar1Landscape).ToString() + getValue(answerVar2Landscape).ToString());

        answer = System.Convert.ToInt32(temp);
        result = getValue(var1Landscape) * getValue(var2Landscape);
        if (answer == result)
        {
            GetComponent<Score>().increaseScore();
            makeProblem();
            AudioSource.PlayClipAtPoint(audioCorrect, transform.position);
        }
        else
        {
            AudioSource.PlayClipAtPoint(audioWrong, transform.position);
        }
        resetNumbers();
    }
}
