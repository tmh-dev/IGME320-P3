using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Represents a player object, i.e. holds stats
public class StatHandler : MonoBehaviour {
    public int strength;
    public int armor;
    public int health;
    public int credits;

    public void TakeDamage(int amount)
    {
        Debug.Log("took damage");
        int combinedHealth = health + armor;
        if (amount > armor)
        {
            health = combinedHealth - amount;
            armor = 0;
        }
            
        else      
            armor -= amount;
        
    }

    public void HealToFull()
    {
        if (health < 5) health = 5;
    }
}
