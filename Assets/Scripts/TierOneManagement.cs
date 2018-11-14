using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class TierOneManagement : MonoBehaviour {

    // Array of possible cards
    public List<GameObject> tierOneList = new List<GameObject>();
    StatManager statHandler;
    int tier = 1;
    int tester;
    int rng;
    public Button generateButton;
    public Button winButton;
    public Button defeatButton;
    public Button tier1Button;
    public Button tier2Button;
    public Button tier3Button;
    public Button tier4Button;
   
    GameObject activeCard;
	// Use this for initialization
	void Start () {
        statHandler = gameObject.GetComponent<StatManager>();
        generateButton.onClick.AddListener(delegate { GenerateCard(tier); });
        winButton.onClick.AddListener(WinBattle);
        defeatButton.onClick.AddListener(LoseBattle);
        tier1Button.onClick.AddListener(delegate { tier = 1; });
        tier2Button.onClick.AddListener(delegate { tier = 2; });
        tier3Button.onClick.AddListener(delegate { tier = 3; });
        tier4Button.onClick.AddListener(delegate { tier = 4; });
        SetBattleButtons(false);

    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(tier);
        CheckCardStatus();
	}
    // Button to generate
    // If clicked present random card
    // If monster - two buttons. One win - one loss
    // If item - accept
    // If outpost - popup equipment. Allow them to choose equipment and slot for it

    void GenerateCard(int tier)
    {
        Debug.Log("Card Generated");
        if(activeCard!= null)
        {
            Destroy(activeCard);
        }
        
        if(tier == 1)
        {
            activeCard = Instantiate(tierOneList[Random.Range(0, tierOneList.Count)], new Vector3(3.65f, 1.0f, -1.0f), Quaternion.identity);
            SetBattleButtons(false);
        }
        
        else if(tier == 2)
        { }
        
        else if(tier == 3)
        { }

        else if(tier == 4)
        { }
    }

    void CheckCardStatus()
    {
        if(activeCard!= null && activeCard.GetComponent<MonsterCard_S>())
        {
            SetBattleButtons(true);
        }

        if(activeCard!= null && activeCard.GetComponent<DiscoverCard>())
        {
            Debug.Log("discover");
        }
        if(activeCard!= null && activeCard.GetComponent<OutpostCard>())
        {
            Debug.Log("Equipment");
        }
    }

    void WinBattle()
    {
        SetBattleButtons(false);
        statHandler.gold += activeCard.GetComponent<MonsterCard_S>().goldReturn;
        statHandler.gold_T.text = "Gold: " + statHandler.gold;
        Destroy(activeCard);
        activeCard = null;
    }

    void LoseBattle()
    {
        SetBattleButtons(false);
        // Deduct from armor first!
        int tempArmor = statHandler.armor;
        if((statHandler.armor - activeCard.GetComponent<MonsterCard_S>().strength) <= 0)
        {
            statHandler.health -= (activeCard.GetComponent<MonsterCard_S>().strength - tempArmor);
            statHandler.health_T.text = "Health: " + statHandler.health;
            statHandler.armor = 0;
        }
        else
        {
            statHandler.armor -= activeCard.GetComponent<MonsterCard_S>().strength;
        }
        statHandler.armor_T.text = "Armor: " + statHandler.armor;
        Destroy(activeCard);
        activeCard = null;
    }

    void SetBattleButtons(bool active)
    {
        winButton.gameObject.SetActive(active);
        defeatButton.gameObject.SetActive(active);
    }

    //// Temp
    //void StatState()
    //{
    //    activeCard = null;
    //    winButton.gameObject.SetActive(false);
    //    defeatButton.gameObject.SetActive(false);
    //    generateButton.gameObject.SetActive(false);
    //}
}
