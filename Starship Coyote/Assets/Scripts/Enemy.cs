using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject hitVFX;
    [SerializeField] GameObject deathVFX;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoints = 5;
    GameObject parentGameObject;
    ScoreBoard scoreBoard;


    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        AddRigidBody();
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
    }

    void AddRigidBody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        hitPoints -= 1;
    }
    
    void KillEnemy()
    {
        scoreBoard.IncreaseScore(scorePerHit);
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
    }
    
}
