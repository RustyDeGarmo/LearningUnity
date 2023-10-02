using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] ParticleSystem collisionParticles;


    bool isTransitioning = false;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{this.name} triggered {other.gameObject.name}");
        if(isTransitioning){ return; }
        StartCrashSequence(); 
        
    }

    void StartCrashSequence()
    {
        collisionParticles.Play();
        isTransitioning = true;
        GetComponent<PlayerControls>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void StartWinSequence()
    {
        isTransitioning = true;
        GetComponent<PlayerControls>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    int getCurrentLevel()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
    void ReloadLevel()
    {
        //reload current level on death
        SceneManager.LoadScene(getCurrentLevel());
    }

    void LoadNextLevel()
    {
        //load the next level on win.
        //if this level is the last level, load the first level
        if(getCurrentLevel() >= SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(getCurrentLevel() + 1);
        }
    }
    
}
