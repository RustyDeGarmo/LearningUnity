using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float destructDelay = 2;
    void Start()
    {
        Destroy(gameObject, destructDelay);
    }
}
