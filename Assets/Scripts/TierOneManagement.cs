using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//REEEEAAAAAAADDDDD MEEEEEEEEEEEEEE 
// MANAGEMENT FOR EVERY TIER NOT JUST ONE

// Overall tier management
public class TierOneManagement : MonoBehaviour {

    // Array of possible cards
    // Set in the inspector with prefabs. These contain monsters,outpost events, and item draw card.
    public List<GameObject> tierOneList = new List<GameObject>();
    public List<GameObject> tierTwoList = new List<GameObject>();
    public List<GameObject> tierThreeList = new List<GameObject>();
    public List<GameObject> tierFourList = new List<GameObject>();

    // References to change stats and equipment
    StatManager statHandler;
    EquipmentManager equipmentHandler;

    // Initial tier the players start on
    int tier = 1;
    
    // Buttons set in inspector
    public Button generateButton; // Generate the event
    public Button winButton;      // Used if the player calculates they win a monster battle.
    public Button defeatButton;   // Used if the player calculates that they lose a monster battle.
    public Button tier1Button;    // These four buttons used to set tiers
    public Button tier2Button;
    public Button tier3Button;
    public Button tier4Button;
   
    // What card is generate from the "Generate" button and currently on the screen?
    // Can be monster card, item card, outpost card.
    public GameObject activeCard;

    // Used to display tier number
    public Text tierStatus;


	// Use this for initialization
	void Start () {

        // Set references
        statHandler = gameObject.GetComponent<StatManager>();
        equipmentHandler = gameObject.GetComponent<EquipmentManager>();

        // Initialize tier text to 1
        tierStatus.text = "Active Tier: " + tier;

        // Button Handlers!
        // First three have own methods.
        generateButton.onClick.AddListener(delegate { GenerateCard(tier); });
        winButton.onClick.AddListener(WinBattle);
        defeatButton.onClick.AddListener(LoseBattle);

        // These are the tier buttons on the top of the screen. They will set the tier accordingly to generate...
        // ...the tier specific monsters and will display the active tier text
        tier1Button.onClick.AddListener(delegate { tier = 1; tierStatus.text = "Active Tier: " + tier; });
        tier2Button.onClick.AddListener(delegate { tier = 2; tierStatus.text = "Active Tier: " + tier; });
        tier3Button.onClick.AddListener(delegate { tier = 3; tierStatus.text = "Active Tier: " + tier; });
        tier4Button.onClick.AddListener(delegate { tier = 4; tierStatus.text = "Active Tier: " + tier; });

        // Sets the win and defeat buttons to be not active. This is just a helper method
        SetBattleButtons(false);

    }
	
	// Update is called once per frame
	void Update () {
        // Always check the status of what kind of card is on the screen.
        CheckCardStatus();
	}
   
    // The "MAIN" button. This will generate a monster depending on the tier, or an outpost or item card.
    // It will also generate the appropriate buttons for the user.
    void GenerateCard(int tier)
    {
        // This is used to clear the previous card.
        if(activeCard!= null)
        {
            Destroy(activeCard);
        }
        
        // If on the first tier
        if(tier == 1)
        {
            // Active card is instantiated from the first tier card list, randomly selected.
            // THERE IS NO RANDOM PROTECTION. They could get the same random result multiple times in a row.
            activeCard = Instantiate(tierOneList[Random.Range(0, tierOneList.Count)], new Vector3(3.65f, 1.0f, -1.0f), Quaternion.identity);

            // This checks to see if the active card instantiated was an outpost card
            if (activeCard != null && activeCard.GetComponent<OutpostCard>())
            {
                // Helper method to display equipment choices
                equipmentHandler.ShowEquipment(true);
            }

            // Hide win and lose buttons 
            SetBattleButtons(false);
        }
        
        // Tier 2!
        else if(tier == 2)
        {
            // Active card taken from the tier two card list
            activeCard = Instantiate(tierTwoList[Random.Range(0, tierTwoList.Count)], new Vector3(3.65f, 1.0f, -1.0f), Quaternion.identity);
            
            // Same deal-io as first tier
            if (activeCard != null && activeCard.GetComponent<OutpostCard>())
            {

                equipmentHandler.ShowEquipment(true);
            }
            
            // Hide win and lose buttons
            SetBattleButtons(false);
        }
        
        // Tier 3! Recognize there is a pattern here.
        // depending on the tier, the active card can become ANY card from the tier dependent list.
        else if(tier == 3)
        {
            activeCard = Instantiate(tierThreeList[Random.Range(0, tierThreeList.Count)], new Vector3(3.65f, 1.0f, -1.0f), Quaternion.identity);
            if (activeCard != null && activeCard.GetComponent<OutpostCard>())
            {

                equipmentHandler.ShowEquipment(true);
            }
            SetBattleButtons(false);
        }

        // Last tier!
        else if(tier == 4)
        {
            activeCard = Instantiate(tierFourList[Random.Range(0, tierFourList.Count)], new Vector3(3.65f, 1.0f, -1.0f), Quaternion.identity);
            if (activeCard != null && activeCard.GetComponent<OutpostCard>())
            {

                equipmentHandler.ShowEquipment(true);
            }
            SetBattleButtons(false);
        }
    }

    // Helper Method to see what type of card the active card was set to.
    void CheckCardStatus()
    {
        // Each statement will check to make sure active card is a proper value.

        // If MONSTER CARD
        if(activeCard!= null && activeCard.GetComponent<MonsterCard_S>())
        {
            // Sets Battle Buttons
            SetBattleButtons(true);
            // Disables Equipment Buttons
            equipmentHandler.ShowEquipment(false);
        }

        // Discover card lets you draw an item from the deck.
        if(activeCard!= null && activeCard.GetComponent<DiscoverCard>())
        {
            // This is manually done, so just hide the unnecessary buttons here
            equipmentHandler.ShowEquipment(false);
        }

        // Don't need this yet I think.
        if(activeCard!= null && activeCard.GetComponent<OutpostCard>())
        {
            // idk yet
        }
    }

    // This is what is called if the user hit's the "WIN" button when a monster battle is presented.
    // The user manually calculates if their strength > monster strength
    // If so they click this - it's an honor system!
    void WinBattle()
    {
        // Hide battle buttons again to reset to generate button.
        SetBattleButtons(false);
        // Add gold from monster win
        statHandler.gold += activeCard.GetComponent<MonsterCard_S>().goldReturn;
        statHandler.gold_T.text = "Gold: " + statHandler.gold;
        // Reset active card
        Destroy(activeCard);
        activeCard = null;
    }

    // This is what is called if the user hit's the "LOSE" button when a monster battle is presented.
    // The user manually calculates if their strength < monster strength
    // If so they click this - it's an honor system!
    void LoseBattle()
    {
        // Hide Battle Buttons again to reset generate button
        SetBattleButtons(false);
        // Calculates damage for stat sheet
        // Deduct from armor first!
        int tempArmor = statHandler.armor;

        // If damage exceeds the armor
        if((statHandler.armor - activeCard.GetComponent<MonsterCard_S>().strength) <= 0)
        {
            // Damage to health of what the armor did not shield
            statHandler.health -= (activeCard.GetComponent<MonsterCard_S>().strength - tempArmor);
            statHandler.health_T.text = "Health: " + statHandler.health;
            statHandler.armor = 0;
        }
        // If damage does not exceed armor simply subtract the armor value
        else
        {
            statHandler.armor -= activeCard.GetComponent<MonsterCard_S>().strength;
        }
        statHandler.armor_T.text = "Armor: " + statHandler.armor;
        // reset active card
        Destroy(activeCard);
        activeCard = null;
    }

    // Simple helper method for setting the battle buttons active or not.
    void SetBattleButtons(bool active)
    {
        winButton.gameObject.SetActive(active);
        defeatButton.gameObject.SetActive(active);
    }

    // Do conditionals for equipment cards here too :(

    //// Temp
    //void StatState()
    //{
    //    activeCard = null;
    //    winButton.gameObject.SetActive(false);
    //    defeatButton.gameObject.SetActive(false);
    //    generateButton.gameObject.SetActive(false);
    //}
}
