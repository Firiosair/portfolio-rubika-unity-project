using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public int playerHealth = 100;
    public int maxPlayerHealth = 100;
    public int playerMana = 100;
    public int maxPlayerMana = 100;
    public float playerXP = 0;
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
    private void AddXp(int x) {playerXP+=x;}
}
