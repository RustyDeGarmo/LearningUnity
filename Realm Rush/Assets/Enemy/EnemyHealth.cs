using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    int currentHitPoints = 0;
    
    void Start()
    {
        currentHitPoints = maxHitPoints;
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
        Destroy(gameObject);
    }
}
