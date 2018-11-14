using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StatManager : MonoBehaviour {
    // Player Stat Manager
    public int strength;
    public int health;
    public int armor;
    public int gold;

    // text
    public Text gold_T;
    public Text health_T;
    public Text armor_T;
    public Text strength_T;
    
	// Use this for initialization
	void Start () {
        // Set initial values
        gold = 0;
        health = 5;
        strength = 3;
        armor = 2;

        // Set initial text values
        gold_T.text = "Gold: " + gold;
        health_T.text = "Health: " + health;
        strength_T.text = "Strength: " + strength;
        armor_T.text = "Armor: " + armor;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
