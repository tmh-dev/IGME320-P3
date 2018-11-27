using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HealManager : MonoBehaviour
{

    public Button healButton;
    public GameObject activePlayerSlot;

    private void Start()
    {
        healButton.onClick.AddListener(HealActivePlayer);
    }

    void HealActivePlayer()
    {
        GameObject activePlayer = activePlayerSlot.GetComponent<StatChanger>().activePlayer;
        activePlayer.GetComponent<StatHandler>().HealToFull();
    }
}
