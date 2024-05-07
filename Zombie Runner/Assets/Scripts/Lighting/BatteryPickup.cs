using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float angle = 70;
    [SerializeField] float intensity = 3;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            FindObjectOfType<FlashLightSystem>().RestoreLightAngle(angle);
            FindObjectOfType<FlashLightSystem>().RestoreLightIntensity(intensity);
            Destroy(gameObject);
        }    
    }
}
