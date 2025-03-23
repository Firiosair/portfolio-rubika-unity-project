using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public int playerHealth = 100;
    public int maxPlayerHealth = 100;
    public int playerMana = 100;
    public int maxPlayerMana = 100;
    public int playerXP = 0;
    public int playerLevel = 0;
    public Dictionary<int, int> xpAssociator = new Dictionary<int, int>(){{0,0},{1,100},{2,250},{3,500},{4,800},{5,1200},{6,1700},{7,2300},{8,3000},{9,4000},{10,5000}};
    void Awake()
    {
        if (instance == null){instance = this;}
        else{Destroy(gameObject);}
    }
    private void AddHealth(int heal)
    {
        playerHealth+=heal;
        HealthCheck();
    }
    private void TakingDamage(int damage)
    {
        playerHealth-=damage;
        HealthCheck();
        if (playerHealth==0){
            Debug.Log("Player is dead");
        }
    }
    private void UseMana(int manaUsed)
    {
        playerMana-=manaUsed;
        ManaCheck();
    }
    private void AddXp(int x) {playerXP+=x;}
    private void HealthCheck()
    {
        if (playerHealth < 0){playerHealth=0;}
        if (playerHealth > maxPlayerHealth){playerHealth=maxPlayerHealth;}
    }
    private void ManaCheck()
    {
        if (playerMana < 0){playerMana=0;}
        if (playerMana > maxPlayerMana){playerMana=maxPlayerHealth;}
    }
    private void XpCheck()
    {
        if (xpAssociator[playerLevel+1] < playerXP){playerLevel+=1;}
    }
}