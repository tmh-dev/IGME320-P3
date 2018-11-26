using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public int playerID;
    public int credits;
    public int strength;
    public int armor;
    public int hp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void TakeDamage(int amount)
    {
        int combinedHealth = armor + hp;
        if (amount >= combinedHealth)
        {
            //death
        }
        else
        {
            combinedHealth -= amount;
            hp = combinedHealth;
        }

    }

  
}
