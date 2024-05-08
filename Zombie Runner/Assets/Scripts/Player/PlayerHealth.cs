using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHP = 100;
    
    void Update()
    {
        
    }

    public void TakeDamage(float dmg)
    {
        playerHP -= dmg;
        if(playerHP <= 0)
        {
            PlayerDeath();
        }
    }
    
    void PlayerDeath()
    {
        GetComponent<DeathHandler>().HandleDeath();
    }
}