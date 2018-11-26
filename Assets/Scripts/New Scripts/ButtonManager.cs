using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {
    public Button eventButton;
    public GameObject eventHierarchy;

	// Use this for initialization
	void Start () {
        eventButton.onClick.AddListener(OpenEvent);
	}
	
	void OpenEvent()
    {
        eventHierarchy.GetComponent<Image>().enabled = true;
    }
}
