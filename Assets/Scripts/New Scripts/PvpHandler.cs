using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PvpHandler : MonoBehaviour {
    public GameObject topSlot;
    public GameObject middleSlot;
    public GameObject bottomSlot;

    public GameObject activeSlot;

	// Use this for initialization
	void Start () {
        topSlot.GetComponent<Button>().onClick.AddListener(TopSlotBattle);
        middleSlot.GetComponent<Button>().onClick.AddListener(MiddleSlotBattle);
        bottomSlot.GetComponent<Button>().onClick.AddListener(BottomSlotBattle);
    }
	
    private void TopSlotBattle()
    {
        StatHandler opponentStats = topSlot.GetComponent<StatManager>().player.GetComponent<StatHandler>();
        StatHandler activeStats = activeSlot.GetComponent<StatManager>().player.GetComponent<StatHandler>();

        opponentStats.TakeDamage(activeStats.strength);
        activeStats.TakeDamage(opponentStats.strength);
    }

    private void MiddleSlotBattle()
    {
        StatHandler opponentStats = middleSlot.GetComponent<StatManager>().player.GetComponent<StatHandler>();
        StatHandler activeStats = activeSlot.GetComponent<StatManager>().player.GetComponent<StatHandler>();

        opponentStats.TakeDamage(activeStats.strength);
        activeStats.TakeDamage(opponentStats.strength);
    }

    private void BottomSlotBattle()
    {
        StatHandler opponentStats = bottomSlot.GetComponent<StatManager>().player.GetComponent<StatHandler>();
        StatHandler activeStats = activeSlot.GetComponent<StatManager>().player.GetComponent<StatHandler>();

        opponentStats.TakeDamage(activeStats.strength);
        activeStats.TakeDamage(opponentStats.strength);
    }
}
