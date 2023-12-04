using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    int currentHitPoints = 0;

    Enemy enemy;
    
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(currentHitPoints <= 0)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        currentHitPoints -= 1;
    }

    void KillEnemy()
    {
        gameObject.SetActive(false);
        enemy.RewardGold();
    }
}
