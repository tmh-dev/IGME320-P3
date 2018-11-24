using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialEventManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEpochChange()
    {
        // change epoch

        // generate a random number
        float rand = Random.Range(0.0f, 1.0f);

        // probability (feel free to tweak this)
        // 10% chance of each event

        /*
         * ***BAD EVENTS***
         * Shields disabled
         * No treasure
         * A random miner crashes into a meteorite and loses a turn
         * Tier 2 monsters begin appearing in Tier 1
         * No gold received from killing monsters
         * ***GOOD EVENTS***
         * All shields +1
         * Monsters are not generated
         * All firepower +1
         * Everyone gets a treasure
         * All miners recover 2 health
         */
    }
}
