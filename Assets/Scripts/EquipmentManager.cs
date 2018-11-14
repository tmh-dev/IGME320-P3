using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;

// Used to Handle Equipment Generation, Selection, and Slot Mechanic
public class EquipmentManager : MonoBehaviour {

    // Player Handler
    StatManager statHandler;

    // This will be the equipment start list for the base. Base equipment generation is not currently implemented.
    public List<GameObject> equipmentStart = new List<GameObject>();
    // Equipment possibilities for each tier. Works slightly different
    // Not dependent on the tier the player is in
    // Rather the left choice is Tier One, middle choice is Tier Two, right choice is Tier Three
    public List<GameObject> equipmentTierOne = new List<GameObject>();
    public List<GameObject> equipmentTierTwo = new List<GameObject>();
    public List<GameObject> equipmentTierThree = new List<GameObject>();

    // When the three equipment choices are displayed on the screen - this holds those three.
    public List<GameObject> equipmentOptionsList = new List<GameObject>();
    
    // Equipment Panel will show the three "Buy" buttons
    public GameObject equipmentPanel;

    // Slot panel will show the insert slot buttons
    public GameObject slotPanel;

    // These are the three buy buttons - poorly named sorry
    public Button equipmentChoice1; // left buy button
    public Button equipmentChoice2; // middle buy button
    public Button equipmentChoice3; // right buy button

    // The equipment piece that the player just chose.
    public GameObject chosenEquipment;
    
    // Selected slot - holds the equipment that is currently in the respective slot.
    public GameObject selectedSlot1;
    public GameObject selectedSlot2;

    // Holds the previously held equipment in the respective slot. Used for calculating stat changes.
    public GameObject prevSlot1;
    public GameObject prevSlot2;

    // Which slot did the player choose to insert the equipment
    public int slotChoice;

    // Slot Buttons
    public Button slot1; // left slot button
    public Button slot2; // right slot button
	// Use this for initialization
	void Start () {
        // Reference to change player stats
        statHandler = gameObject.GetComponent<StatManager>();
        // Hide panels on start
        equipmentPanel.SetActive(false);
        slotPanel.SetActive(false);
        // Buy Buttons - have helper method
        equipmentChoice1.onClick.AddListener(delegate { BuyEquipment(1); });
        equipmentChoice2.onClick.AddListener(delegate { BuyEquipment(2); });
        equipmentChoice3.onClick.AddListener(delegate { BuyEquipment(3); });
        // Slot Buttons - have helper method
        slot1.onClick.AddListener(delegate { SelectSlot(1); });
        slot2.onClick.AddListener(delegate { SelectSlot(2); });
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // This will present the three equipment choices
    public void ShowEquipment(bool check)
    {
        // Set panel active
        equipmentPanel.SetActive(check);
        // If active
        if(check)
        {
            // Displays three choices from each array of equipment options
                // Equipment is done by randomly choosing a piece out of each tier. There are three tiers of equipment.
                equipmentOptionsList.Add(Instantiate(equipmentTierOne[Random.Range(0, equipmentTierOne.Count)], new Vector3(-1.0f, 1.0f, 0.0f), Quaternion.identity));
                equipmentOptionsList.Add(Instantiate(equipmentTierTwo[Random.Range(0, equipmentTierTwo.Count)], new Vector3(2.0f, 1.0f, 0.0f), Quaternion.identity));
                equipmentOptionsList.Add(Instantiate(equipmentTierThree[Random.Range(0, equipmentTierThree.Count)], new Vector3(5.0f, 1.0f, 0.0f), Quaternion.identity));
                
        }   
        else // if panel is not active
        {
            // Remove the equipment choices from screen
            foreach(GameObject option in equipmentOptionsList)
            {
                Destroy(option);
                
                
                
            }
            // Reset equipmentOptionsList --- remember this only holds the currently present choices!
            equipmentOptionsList.Clear();
        }
        
    }

    // Buy equipment - hooked to the buy buttons
    // i.e. the first buy button will be choice 1 and choose the left piece
    void BuyEquipment(int choice)
    {
        
        if(choice == 1)
        {
            // Set the chosen equipment to the piece the player selects
            chosenEquipment = Instantiate(equipmentOptionsList[0], new Vector3(3.65f, 1.0f, 0.0f), Quaternion.identity);
            statHandler.gold -= equipmentOptionsList[0].GetComponent<EquipmentCard>().goldCost; // Reduces the stat sheet gold
            // There is no check to see if the player holds enough gold. They currently manually calculate it.
        }
        // Same deal
        else if (choice == 2)
        {
            
            chosenEquipment = Instantiate(equipmentOptionsList[1], new Vector3(3.65f, 1.0f, 0.0f), Quaternion.identity);
            statHandler.gold -= equipmentOptionsList[1].GetComponent<EquipmentCard>().goldCost;
        }
        // Same deal
        else if(choice == 3)
        {
            
            chosenEquipment = Instantiate(equipmentOptionsList[2], new Vector3(3.65f, 1.0f, 0.0f), Quaternion.identity);
            statHandler.gold -= equipmentOptionsList[2].GetComponent<EquipmentCard>().goldCost;
        }

        // Update gold text
        statHandler.gold_T.text = "Gold: " + statHandler.gold;
        // After player buys 
        // hide equipment panel --> present panel for them to choose the slot for equipment
        ShowEquipment(false);
        slotPanel.SetActive(true);
    }

    // Allows player to select which slot the equipment goes in
    // Two slots available
    // Hooked to the slotButton
    // if they choose left slot button - assigns it to slot 1, etc
    void SelectSlot(int slot)
    {
        // First slot
        if(slot == 1)
        {
            // Helper method to clear the first slots previous held equipment
            clearPrevEquipment(1);
            Destroy(selectedSlot1);
            // Fill the slot with the chosen equipment and shift it to the appropriate area
            selectedSlot1 = chosenEquipment;
            selectedSlot1.transform.position = new Vector3(-5.0f, -3.0f, 0.0f);
            // Hide the slot panel since user chose
            slotPanel.SetActive(false);
            // Update the stats
            changeStats();
        }

        // Same deal as above
        if(slot == 2)
        {
            clearPrevEquipment(2);
            Destroy(selectedSlot2);
            selectedSlot2 = chosenEquipment;
            selectedSlot2.transform.position = new Vector3(-2.0f, -3.0f, 0.0f);
            slotPanel.SetActive(false);
            changeStats();
        }
    }

    // Helper Method
    // Equipment will override the stats of the previous one. 
    // The equipment is ONLY ever adding onto the base stats
    // i.e base armor = 2
    // first equipment increases armor by 1 so -> armor = 3
    // player later chooses to slot in a new equipment that increases armor. armor will be = 6, not = 7
    void changeStats()
    {
       
        // Add equipment stats to the player stat sheet
        statHandler.strength += chosenEquipment.GetComponent<EquipmentCard>().strengthBoost;
        statHandler.health += chosenEquipment.GetComponent<EquipmentCard>().healthBoost;
        statHandler.armor += chosenEquipment.GetComponent<EquipmentCard>().armorBoost;

        // display updated text
        statHandler.strength_T.text = "Strength: " + statHandler.strength;
        statHandler.health_T.text = "Health: " + statHandler.health;
        statHandler.armor_T.text = "Armor: " + statHandler.armor;
        // Assign previous slots
        prevSlot1 = selectedSlot1;
        prevSlot2 = selectedSlot2;
    }

    // For when player puts a new equipment into an already filled slot
    // Will clear the slot and revert the previous equipment stat changes.
    void clearPrevEquipment(int slot)
    {
        // Slot 1 override
        if(slot == 1 && prevSlot1 != null)
        {
            // Revert previous equipment changes
            statHandler.strength -= prevSlot1.GetComponent<EquipmentCard>().strengthBoost;
            statHandler.health -= prevSlot1.GetComponent<EquipmentCard>().healthBoost;
            statHandler.armor -= prevSlot1.GetComponent<EquipmentCard>().armorBoost;
        }
        // Same deal as above
        else if(slot == 2 && prevSlot2 != null)
        {
            statHandler.strength -= prevSlot2.GetComponent<EquipmentCard>().strengthBoost;
            statHandler.health -= prevSlot2.GetComponent<EquipmentCard>().healthBoost;
            statHandler.armor -= prevSlot2.GetComponent<EquipmentCard>().armorBoost;
        }
        // Update Text
        statHandler.strength_T.text = "Strength: " + statHandler.strength;
        statHandler.health_T.text = "Health: " + statHandler.health;
        statHandler.armor_T.text = "Armor: " + statHandler.armor;
    }
}
