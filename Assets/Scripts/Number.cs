using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Number : MonoBehaviour {
    public int index = 0; // the integer value for this number, and the index for which image to use
    public Sprite[] images;// an array of number sprites from 0 to 9
    public Sprite mySprite;// the current sprite being displayed on screen

    /**
     * @return the integer value and current sprite of the number object
     * 
     */
    public int getIndex()
    {
        return index;
    }

    /**
     * sets the current integer value, and sprite in a 2d sprite or ui image
     * 
     * @param value the value of the index
     * 
     */
    public void setIndex(int value)
    {
        index = value;
        mySprite = images[index];
        if (GetComponent<SpriteRenderer>() != null)
        {
            GetComponent<SpriteRenderer>().sprite = mySprite;
        }
        else
        {
            transform.GetComponent<Image>().sprite = mySprite;
        }
    }

}
