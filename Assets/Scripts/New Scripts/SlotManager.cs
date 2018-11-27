using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour {
    public List<GameObject> players;
    public List<GameObject> slots;
    public List<Text> titleSlots;

    public int activePlayerID;
    public int topPlayerID;
    public int middlePlayerID;
    public int bottomPlayerID;

	// Use this for initialization
	void Start () {
        activePlayerID = 0;
        topPlayerID = 1;
        middlePlayerID = 2;
        bottomPlayerID = 3;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            activePlayerID++;
            topPlayerID++;
            middlePlayerID++;
            bottomPlayerID++;
            if (activePlayerID > 3)          
                activePlayerID = 0;
            if (topPlayerID > 3)
                topPlayerID = 0;
            if (middlePlayerID > 3)
                middlePlayerID = 0;
            if (bottomPlayerID > 3)
                bottomPlayerID = 0;


            //active slot
            slots[0].GetComponent<StatChanger>().activePlayer = players[activePlayerID];
            slots[0].GetComponent<StatManager>().player = players[activePlayerID];
            slots[0].GetComponent<StatChanger>().switched = true;
            titleSlots[0].GetComponent<Text>().text = "Player " + (activePlayerID + 1);
            //top slot
            slots[1].GetComponent<StatManager>().player = players[topPlayerID];
            titleSlots[1].GetComponent<Text>().text = "P" + (topPlayerID + 1);

            //middle slot
            slots[2].GetComponent<StatManager>().player = players[middlePlayerID];
            titleSlots[2].GetComponent<Text>().text = "P" + (middlePlayerID + 1);
            //bottom slot
            slots[3].GetComponent<StatManager>().player = players[bottomPlayerID];
            titleSlots[3].GetComponent<Text>().text = "P" + (bottomPlayerID + 1);
        }
	}
}
