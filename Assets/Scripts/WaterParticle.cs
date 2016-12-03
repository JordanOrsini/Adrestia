﻿using UnityEngine;
using System.Collections;

public class WaterParticle : MonoBehaviour
{
    public AudioSource destructionSound;
	public AudioSource boilerpuzzlestartsound;

    AudioSource myDestructionSound;
	AudioSource puzzlestartSound;



    void Start()
    {
        myDestructionSound = destructionSound.GetComponent<AudioSource>();
		puzzlestartSound = boilerpuzzlestartsound.GetComponent<AudioSource>();
	
    }

    void OnParticleCollision(GameObject obj)
    {
        if(obj.tag == "WeakToWater")
        {
            Instantiate(myDestructionSound);
            Destroy(obj);
        }

		if (obj.tag == "Boss") {
			obj.GetComponent<BossControl> ().Hit ();
			print ("Hit boss");
		}

		if (obj.tag == "GrowOnWater") {
			obj.GetComponent<BridgeController> ().Grow();
		}




		if(obj.tag == "water_interaction")
		{
			
			Instantiate (puzzlestartSound);
			boiler_puzzle.boiler_water_time =30.00f;

		}

        if(obj.name != "Mage" && obj.tag != "Planet")
        {
            gameObject.GetComponent<ParticleSystem>().Clear();
        }
    }
}
