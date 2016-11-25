﻿using UnityEngine;
using System.Collections;

public class RightPuzzleScript : MonoBehaviour 
{
    public GameObject plateUp;
    public GameObject plateDown;
    public GameObject plateLeft;
    public GameObject plateRight;
    public GameObject puzzleController;
    public GameObject rightReset;

    RightPuzzlePlateScript plateUpScript;
    RightPuzzlePlateScript plateDownScript;
    RightPuzzlePlateScript plateLeftScript;
    RightPuzzlePlateScript plateRightScript;
    RightResetScript rightResetScript;

    PuzzleController myController;

    int achieved;
    int randomNumber;
    float randomGlowDelay;
    bool puzzleStart;

	void Start () 
    {
        rightResetScript = rightReset.GetComponent<RightResetScript>();
        plateUpScript = plateUp.GetComponent<RightPuzzlePlateScript>();
        plateDownScript = plateDown.GetComponent<RightPuzzlePlateScript>();
        plateLeftScript = plateLeft.GetComponent<RightPuzzlePlateScript>();
        plateRightScript = plateRight.GetComponent<RightPuzzlePlateScript>();
        myController = puzzleController.GetComponent<PuzzleController>();
        achieved = 0;
        randomNumber = 0;
        randomGlowDelay = Time.time + 3f;
        puzzleStart = false;
	}
	
	void Update () 
    {
        if(achieved == 5)
        {
            myController.setPuzzleRightComplete();
            turnAllGreen();
        }

        if(puzzleStart == true)
        {
            if(Time.time > randomGlowDelay)
            {
                newRandom();
                if(randomNumber == 1)
                {
                    plateUpScript.turnBlue();
                    randomGlowDelay = Time.time + 3f;
                }
                if(randomNumber == 2)
                {
                    plateDownScript.turnBlue();
                    randomGlowDelay = Time.time + 3f;
                }
                if(randomNumber == 3)
                {
                    plateLeftScript.turnBlue();
                    randomGlowDelay = Time.time + 3f;
                }
                if(randomNumber == 4)
                {
                    plateRightScript.turnBlue();
                    randomGlowDelay = Time.time + 3f;
                }
            }
        }
	}

    public void incrementAchieved()
    {
        if(achieved < 5)
        {
            achieved ++;
        }
    }

    public void resetAchieved()
    {
        achieved = 0;
    }

    public void newRandom()
    {
        randomNumber = Random.Range(1, 5);
        Debug.Log(randomNumber);
        allReset();
    }

    public void turnAllGreen()
    {
        plateUpScript.turnGreen();
        plateDownScript.turnGreen();
        plateLeftScript.turnGreen();
        plateRightScript.turnGreen();
        rightResetScript.turnGreen();
    }

    public void allFailed()
    {
        plateUpScript.turnRed();
        plateDownScript.turnRed();
        plateLeftScript.turnRed();
        plateRightScript.turnRed();
        rightResetScript.setCanBeReset();
        puzzleStart = false;
    }

    public void allReset()
    {
        puzzleStart = true;
        plateUpScript.turnWhite();
        plateDownScript.turnWhite();
        plateLeftScript.turnWhite();
        plateRightScript.turnWhite();
    }

    public void setPuzzleStart()
    {
        puzzleStart = true;
    }

    public void setDoNotStart()
    {
        puzzleStart = false;
    }
}
