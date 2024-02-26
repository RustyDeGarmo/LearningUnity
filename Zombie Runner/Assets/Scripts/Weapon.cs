using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 20f;
    
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
        if(Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.collider.name);
            // TODO: add vfx

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if(target == null) return;

            target.TakeDamage(damage); 
            Debug.Log(target.GetHP() + " HP remaining");
            
        }
        else
        {
            return;
        }
        

        
    }
}
