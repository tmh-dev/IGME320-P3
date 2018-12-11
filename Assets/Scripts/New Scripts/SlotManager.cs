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

    public Button endTurnButton;
    public GameObject eventButton;
    public GameObject pvpButton;

	// Use this for initialization
	void Start () {
        activePlayerID = 0;
        topPlayerID = 1;
        middlePlayerID = 2;
        bottomPlayerID = 3;
        players[activePlayerID].GetComponent<StatHandler>().isActive = true;
        endTurnButton.onClick.AddListener(SwitchPlayerSlots);
	}

    private void SwitchPlayerSlots()
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
        players[activePlayerID].GetComponent<StatHandler>().isActive = true;
        //top slot
        slots[1].GetComponent<StatManager>().player = players[topPlayerID];
        titleSlots[1].GetComponent<Text>().text = "P" + (topPlayerID + 1);
        players[topPlayerID].GetComponent<StatHandler>().isActive = false;

        //middle slot
        slots[2].GetComponent<StatManager>().player = players[middlePlayerID];
        titleSlots[2].GetComponent<Text>().text = "P" + (middlePlayerID + 1);
        players[middlePlayerID].GetComponent<StatHandler>().isActive = false;
        //bottom slot
        slots[3].GetComponent<StatManager>().player = players[bottomPlayerID];
        titleSlots[3].GetComponent<Text>().text = "P" + (bottomPlayerID + 1);
        players[bottomPlayerID].GetComponent<StatHandler>().isActive = false;

        Destroy(eventButton.GetComponent<EventManager>().eventCard);
        pvpButton.GetComponent<PvpManager>().pvpCard.SetActive(false);
        pvpButton.GetComponent<PvpManager>().pvpCard.GetComponent<PvpHandler>().enabled = false;
    }
}
