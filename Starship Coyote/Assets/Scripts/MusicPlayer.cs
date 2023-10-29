using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake() 
    {   
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;

        if(numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update() {
        //when the timeline gets to the 'boss' change the audio clip
    }
}
