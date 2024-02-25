using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }   
    }

    private void Shoot()
    {
        RaycastHit hit;
        Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range);

        Debug.Log(hit.collider.name);
    }
}
