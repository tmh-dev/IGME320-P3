using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CombatManager : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    //reference to the canvas element
    public GameObject canvas;

    //ui element to load
    public GameObject combatSelectPrefab;

    //object to instantiate
    public GameObject combatSelectCard;

    public GameObject leftPlayerButtonPrefab;
    public GameObject middlePlayerButtonPrefab;
    public GameObject rightPlayerButtonPrefab;

    private GameObject leftPlayerButton;
    private GameObject middlePlayerButton;
    private GameObject rightPlayerButton;

    public GameObject activePlayerWonButton;
    public GameObject opponentPlayerWonButton;

    public GameObject activePlayer;
    public GameObject opponentPlayer;


    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log(this.gameObject.name + " was selected");
        combatSelectCard = Instantiate(combatSelectPrefab);
        combatSelectCard.transform.SetParent(canvas.transform, false);
        combatSelectCard = Instantiate(combatSelectPrefab);
        combatSelectCard.transform.SetParent(canvas.transform, false);
        combatSelectCard = Instantiate(combatSelectPrefab);
        combatSelectCard.transform.SetParent(canvas.transform, false);
    }

    public void OnDeselect(BaseEventData evenData)
    {
        Debug.Log(this.gameObject.name + " was deselcted");
        Destroy(combatSelectCard);
    }

    void Battle()
    {
        StatHandler activePlayerStats = activePlayer.GetComponent<StatHandler>();
        StatHandler opponentPlayerStats = opponentPlayer.GetComponent<StatHandler>();
        activePlayerWonButton.GetComponent<Button>().onClick.AddListener(() => activePlayerStats.TakeDamage(opponentPlayerStats.strength));

    }
}
