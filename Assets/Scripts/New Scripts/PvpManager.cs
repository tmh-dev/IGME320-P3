using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PvpManager : MonoBehaviour, ISelectHandler
{

    public GameObject pvpPrefab;
    public GameObject canvas;
    public GameObject pvpCard;

    public GameObject eventButton;

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log(this.gameObject.name + " was selected");
        //pvpCard = Instantiate(pvpPrefab);
        //pvpCard.transform.SetParent(canvas.transform, false);
        //pvpCard.GetComponent<Image>().enabled = true;
        pvpCard.GetComponent<PvpHandler>().enabled = true;
        pvpCard.SetActive(true);
        Destroy(eventButton.GetComponent<EventManager>().eventCard);
    }

}
