using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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


    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log(this.gameObject.name + " was selected");
        combatSelectCard = Instantiate(combatSelectPrefab);
        combatSelectCard.transform.SetParent(canvas.transform, false);
    }

    public void OnDeselect(BaseEventData evenData)
    {
        Debug.Log(this.gameObject.name + " was deselcted");
        Destroy(combatSelectCard);
    }
}
