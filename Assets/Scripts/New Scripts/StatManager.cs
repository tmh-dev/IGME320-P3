using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour {
    public GameObject player;
    private StatHandler stats;

    public Text strengthText;
    public Text armorText;
    public Text healthText;
    public Text creditText;

	// Use this for initialization
	void Start () {
        stats = player.GetComponent<StatHandler>();
	}
	
	// Keep stats updated with any changes
	void Update () {
        stats = player.GetComponent<StatHandler>();
        strengthText.GetComponent<Text>().text = stats.strength.ToString();
        armorText.GetComponent<Text>().text = stats.armor.ToString();
        healthText.GetComponent<Text>().text = stats.health.ToString();
        creditText.GetComponent<Text>().text = stats.credits.ToString();
    }
}
