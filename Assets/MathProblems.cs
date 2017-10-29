using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathProblems : MonoBehaviour {

    public GameObject var1; // sprite for digit 1 of problem.
    public GameObject var2; // sprite for digit 2 of problem
    public GameObject answerVar1;//sprite for digit 1 of the answer
    public GameObject answerVar2;//sprite for digit 2 of the answer
    private int answerIndex = 0;//current digit of the number are you inputting?
    //private int answerLimit = 2;
    private int answer;//the players answer to the problem
    private int result;//the real result to the problem

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
        setValue(var1,Random.Range(0, 9));
        setValue(var2, Random.Range(0, 9));
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
                setValue(answerVar2, value);
                answerIndex++;
            }
            else
            {
                swapNumbers();
                setValue(answerVar2, value);
                
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
        setValue(answerVar1, getValue(answerVar2));
     
    }

    /**
     * sets the answer variables back to 0 and sets the cursor to the one on the right
     */
    void resetNumbers()
    {
        setValue(answerVar1, 0);
        setValue(answerVar2, 0);
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
        string temp = (getValue(answerVar1).ToString() + getValue(answerVar2).ToString());
        answer = System.Convert.ToInt32(temp);
        result = getValue(var1) * getValue(var2);
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
