using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventHandler : MonoBehaviour {
    public GameObject activePlayer;
    public Button winButton;
    public Button loseButton;
    public Button fleeButton;

    public Text eventTitleText;

    public Text treasureResultText;


	// Use this for initialization
	void Start () {
        activePlayer = GameObject.Find("Active Player Slot").GetComponent<StatChanger>().activePlayer;
        StatHandler stats = activePlayer.GetComponent<StatHandler>();
        int rand = Random.Range(1, 8);
        if (rand >= 1 && rand <= 4)
        {
            eventTitleText.GetComponent<Text>().text = "Enemy";

            winButton.GetComponent<Image>().enabled = true;
            winButton.GetComponent<Button>().enabled = true;

            loseButton.GetComponent<Image>().enabled = true;
            loseButton.GetComponent<Button>().enabled = true;
            loseButton.onClick.AddListener(() => stats.TakeDamage(5));

            fleeButton.GetComponent<Image>().enabled = true;
            fleeButton.GetComponent<Button>().enabled = true;
        }
        else if (rand == 5)
        {
            eventTitleText.GetComponent<Text>().text = "Outpost";
        }
        else
        {
            eventTitleText.GetComponent<Text>().text = "Treasure";

            int treasureRand = Random.Range(1, 4);           
            treasureResultText.GetComponent<Text>().enabled = true;
            treasureResultText.GetComponent<Text>().text = "Draw " + treasureRand + "\n item cards";
        }
	}

	

}
