using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventHandler : MonoBehaviour {
    public GameObject activePlayer;
    public Button winButton;
    public Button loseButton;
    public Button fleeButton;

    public Text eventTitleText;

    public Text treasureResultText;

    public List<Sprite> tier1List;
    public List<Sprite> tier2List;
    public List<Sprite> tier3List;
    public List<Sprite> tier4List;

    public Button tier1Button;
    public Button tier2Button;
    public Button tier3Button;
    public Button tier4Button;

    public Image image;


    // Use this for initialization
    void Start () {
        activePlayer = GameObject.Find("Active Player Slot").GetComponent<StatChanger>().activePlayer;
        StatHandler stats = activePlayer.GetComponent<StatHandler>();
        int rand = Random.Range(1, 8);
        if (rand >= 1 && rand <= 4)
        {
            eventTitleText.GetComponent<Text>().text = "Enemy";

            //tier buttons activate
            tier1Button.GetComponent<Image>().enabled = true;
            tier1Button.GetComponent<Button>().enabled = true;
            tier1Button.onClick.AddListener(SpawnTier1);

            tier2Button.GetComponent<Image>().enabled = true;
            tier2Button.GetComponent<Button>().enabled = true;
            tier2Button.onClick.AddListener(SpawnTier2);

            tier3Button.GetComponent<Image>().enabled = true;
            tier3Button.GetComponent<Button>().enabled = true;
            tier3Button.onClick.AddListener(SpawnTier3);

            tier4Button.GetComponent<Image>().enabled = true;
            tier4Button.GetComponent<Button>().enabled = true;
            tier4Button.onClick.AddListener(SpawnTier4);
        }
        else if (rand == 5)
        {
            eventTitleText.GetComponent<Text>().text = "Outpost";
        }
        else if (rand == 6 || rand == 7)
        {
            eventTitleText.GetComponent<Text>().text = "Treasure";

            int treasureRand = Random.Range(1, 4);           
            treasureResultText.GetComponent<Text>().enabled = true;
            treasureResultText.GetComponent<Text>().text = "Draw " + treasureRand + "\n item cards";
        }
	}

    private void SpawnTier1()
    {
        int rand = Random.Range(0, tier1List.Count);
        image.sprite = tier1List[rand];
        //EnableResultButtons();
        DisableTierButtons();
    }

    private void SpawnTier2()
    {
        int rand = Random.Range(0, tier2List.Count);
        image.sprite = tier2List[rand];
        //EnableResultButtons();
        DisableTierButtons();
    }

    private void SpawnTier3()
    {
        int rand = Random.Range(0, tier3List.Count);
        image.sprite = tier3List[rand];
        //EnableResultButtons();
        DisableTierButtons();
    }

    private void SpawnTier4()
    {
        int rand = Random.Range(0, tier4List.Count);
        image.sprite = tier4List[rand];
        //EnableResultButtons();
        DisableTierButtons();
    }

    private void EnableResultButtons()
    {
        winButton.GetComponent<Image>().enabled = true;
        winButton.GetComponent<Button>().enabled = true;

        loseButton.GetComponent<Image>().enabled = true;
        loseButton.GetComponent<Button>().enabled = true;
        //loseButton.onClick.AddListener(() => stats.TakeDamage(5));

        fleeButton.GetComponent<Image>().enabled = true;
        fleeButton.GetComponent<Button>().enabled = true;
    }

    private void DisableTierButtons()
    {
        eventTitleText.GetComponent<Text>().text = "";

        tier1Button.GetComponent<Image>().enabled = false;
        tier1Button.GetComponent<Button>().enabled = false;

        tier2Button.GetComponent<Image>().enabled = false;
        tier2Button.GetComponent<Button>().enabled = false;

        tier3Button.GetComponent<Image>().enabled = false;
        tier3Button.GetComponent<Button>().enabled = false;

        tier4Button.GetComponent<Image>().enabled = false;
        tier4Button.GetComponent<Button>().enabled = false;
    }
}
