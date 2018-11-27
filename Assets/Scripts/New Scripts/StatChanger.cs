using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatChanger : MonoBehaviour {
    public GameObject activePlayer;

    public Button strPlusButton;
    public Button strMinusButton;

    public Button armorPlusButton;
    public Button armorMinusButton;

    public Button healthPlusButton;
    public Button healthMinusButton;

    // Use this for initialization
    void Start () {
        StatHandler stats = activePlayer.GetComponent<StatHandler>();

        strPlusButton.onClick.AddListener(()=> stats.strength++);
        strMinusButton.onClick.AddListener(() => stats.strength--);

        armorPlusButton.onClick.AddListener(() => stats.armor++);
        armorMinusButton.onClick.AddListener(() => stats.armor--);

        healthPlusButton.onClick.AddListener(() => stats.health++);
        healthMinusButton.onClick.AddListener(() => stats.health--);
    }
}
