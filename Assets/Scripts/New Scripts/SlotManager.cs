using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour {
    public List<GameObject> players;
    public List<GameObject> slots;

    public Text activeSlot;

    public int activePlayerID;

	// Use this for initialization
	void Start () {
        activePlayerID = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            activePlayerID++;
            if (activePlayerID > 3)          
                activePlayerID = 0;


            //active slot
            slots[0].GetComponent<StatChanger>().activePlayer = players[activePlayerID];
            slots[0].GetComponent<StatManager>().player = players[activePlayerID];
            activeSlot.GetComponent<Text>().text = "Player " + (activePlayerID + 1);
            //top slot
            slots[1].GetComponent<StatManager>().player = players[1];

            //middle slot
            slots[2].GetComponent<StatManager>().player = players[2];
            //bottom slot
            slots[3].GetComponent<StatManager>().player = players[3];

        }
	}
}
