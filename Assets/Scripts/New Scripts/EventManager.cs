using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EventManager : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public GameObject eventPrefab;
    public GameObject canvas;
    public GameObject eventCard;
    
    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log(this.gameObject.name + " was selected");
        eventCard = Instantiate(eventPrefab);
        eventCard.transform.SetParent(canvas.transform, false);
    }
    
    public void OnDeselect(BaseEventData evenData)
    {
        Debug.Log(this.gameObject.name + " was deselcted");
        Destroy(eventCard, .1f);
    }
}
