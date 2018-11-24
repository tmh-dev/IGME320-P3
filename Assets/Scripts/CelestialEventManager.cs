using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CelestialEventManager : MonoBehaviour
{

    // enum to keep track of the current event for the turn
    public enum CelestialEvent
    {
        NoEvent,
        ShieldsDisabled,
        NoTreasure,
        Meteorite,
        TierInvasion,
        NoGold,
        AllShieldsPlus1,
        NoEnemies,
        AllFirepowerPlus1,
        TreasureForEveryone,
        AllHealthPlus2
    };
    public CelestialEvent currentEvent;

    // array of probabilities of each event, one for each entry in the enum
    private float[] probabilities;

    // Use this for initialization
    void Start()
    {
        // at the start of the game, no event takes place on the first epoch
        currentEvent = CelestialEvent.NoEvent;

        // hard coded probabilities out of 1.0f (tweak the constant values as needed).
        // the reason why each successive probability adds the previous one is because
        // of the if-else chain in the logic for distributed random
        probabilities = new float[11];
        // probability of no event will be calculated later
        probabilities[(int)CelestialEvent.ShieldsDisabled]      = 0.0f + probabilities[(int)CelestialEvent.NoEvent];
        probabilities[(int)CelestialEvent.NoTreasure]           = 0.0f + probabilities[(int)CelestialEvent.ShieldsDisabled];
        probabilities[(int)CelestialEvent.Meteorite]            = 0.0f + probabilities[(int)CelestialEvent.NoTreasure];
        probabilities[(int)CelestialEvent.TierInvasion]         = 0.0f + probabilities[(int)CelestialEvent.Meteorite];
        probabilities[(int)CelestialEvent.NoGold]               = 0.0f + probabilities[(int)CelestialEvent.TierInvasion];
        probabilities[(int)CelestialEvent.AllShieldsPlus1]      = 0.0f + probabilities[(int)CelestialEvent.NoGold];
        probabilities[(int)CelestialEvent.NoEnemies]            = 0.0f + probabilities[(int)CelestialEvent.AllShieldsPlus1];
        probabilities[(int)CelestialEvent.AllFirepowerPlus1]    = 0.0f + probabilities[(int)CelestialEvent.NoEnemies];
        probabilities[(int)CelestialEvent.TreasureForEveryone]  = 0.0f + probabilities[(int)CelestialEvent.AllFirepowerPlus1];
        probabilities[(int)CelestialEvent.AllHealthPlus2]       = 0.0f + probabilities[(int)CelestialEvent.TreasureForEveryone];
        
        // ensure that all probabilities add up to 1.0f
        float totalSum = probabilities[(int)CelestialEvent.AllHealthPlus2];
        if (totalSum > 1.0f)
        {
            // this is bad
            Debug.Log("Probabilities add up to " + totalSum + ", not 1!");
        }
        else if (totalSum < 1.0f)
        {
            // if the probabilities of the individual events is too small,
            // increase the odds of no event taking place
            // in order for this to work, the odds of no event MUST initially be set to 0
            probabilities[(int)CelestialEvent.NoEvent] = 1.0f - totalSum;
            Debug.Log("Probability of no event = " + probabilities[(int)CelestialEvent.NoEvent]);
        }
        else
        {
            Debug.Log("probabilities add up to " + totalSum);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    // call this function from the turn management code when everyone has gone and the epoch advances
    CelestialEvent OnEpochChange()
    {
        // generate a random number
        float rand = Random.Range(0.0f, 1.0f);

        // probability (feel free to tweak this)
        // 10% chance of each event

        // ***BAD EVENTS***
        // Shields disabled
        if (rand < probabilities[(int)CelestialEvent.NoEvent])
        {
            currentEvent = CelestialEvent.NoEvent;
        }
        else if (rand < probabilities[(int)CelestialEvent.ShieldsDisabled])
        {
            currentEvent = CelestialEvent.ShieldsDisabled;
        }
        // No treasure
        else if (rand < probabilities[(int)CelestialEvent.NoTreasure])
        {
            currentEvent = CelestialEvent.NoTreasure;
        }
        // A random miner crashes into a meteorite and loses a turn
        else if (rand < probabilities[(int)CelestialEvent.Meteorite])
        {
            currentEvent = CelestialEvent.Meteorite;
        }
        // Tier 2 monsters begin appearing in Tier 1
        else if (rand < probabilities[(int)CelestialEvent.TierInvasion])
        {
            currentEvent = CelestialEvent.TierInvasion;
        }
        // No gold received from killing monsters
        else if (rand < probabilities[(int)CelestialEvent.NoGold])
        {
            currentEvent = CelestialEvent.NoGold;
        }
        // ***GOOD EVENTS***
        // All shields +1
        else if (rand < probabilities[(int)CelestialEvent.AllShieldsPlus1])
        {
            currentEvent = CelestialEvent.AllShieldsPlus1;
        }
        // Enemies are not generated
        else if (rand < probabilities[(int)CelestialEvent.NoEnemies])
        {
            currentEvent = CelestialEvent.NoEnemies;
        }
        // All firepower +1
        else if (rand < probabilities[(int)CelestialEvent.AllFirepowerPlus1])
        {
            currentEvent = CelestialEvent.AllFirepowerPlus1;
        }
        // Everyone gets a treasure
        else if (rand < probabilities[(int)CelestialEvent.TreasureForEveryone])
        {
            currentEvent = CelestialEvent.TreasureForEveryone;
        }
        // All miners recover 2 health
        else if (rand < probabilities[(int)CelestialEvent.AllHealthPlus2])
        {
            currentEvent = CelestialEvent.AllHealthPlus2;
        }

        return currentEvent;
    }
}
