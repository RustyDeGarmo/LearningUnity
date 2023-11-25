using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] GameObject towerPrefab;
    void OnMouseDown() 
    {
        if(isPlaceable)
        {
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
        }
    }
}
