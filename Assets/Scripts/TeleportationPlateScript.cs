﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TeleportationPlateScript : MonoBehaviour 
{
    public Material red;
    public Material white;
    public Material green;
    public Material blue;

    Renderer myRend;

    float flashDelay;
    bool flashWhite;
    bool shouldFlash;

    void Start()
    {
        myRend = GetComponent<Renderer>();
        flashDelay = Time.time + 1f;
        flashWhite = true;
        shouldFlash = true;
    }

    void Update()
    {
        if(Time.time > flashDelay && flashWhite == true && shouldFlash == true)
        {
            turnWhite();
            flashWhite = false;
            flashDelay = Time.time + 1f;
        }
        if(Time.time > flashDelay && flashWhite == false && shouldFlash == true)
        {
            turnGreen();
            flashWhite = true;
            flashDelay = Time.time + 1f;
        }
    }
    void turnGreen()
    {
        myRend.material = green;
    }

    void turnWhite()
    {
        myRend.material = white;
    }

    void turnRed()
    {
        myRend.material = red;
    }

    void turnBlue()
    {
        myRend.material = blue;
    }
        
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Mage")
        {
            SceneManager.LoadScene("FirePlanet");
        }
    }
}