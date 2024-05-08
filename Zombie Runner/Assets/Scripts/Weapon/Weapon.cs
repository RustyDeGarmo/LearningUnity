using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 20f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] TextMeshProUGUI ammoText;
    
    bool canShoot = true;
    
    void OnEnable() 
    {   
        canShoot = true;
        //lets the player shoot faster than intended if weapon is cycled 
        //between shots but I don't know how to fix this yet.
    }

    void Update()
    {
        DisplayAmmo();

        if(Input.GetMouseButtonDown(0) && canShoot)
        {
            StartCoroutine(Shoot());         
        }   
    }

    void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmoAmount(ammoType);
        ammoText.text = "Ammo: " + currentAmmo.ToString();
    }

    IEnumerator Shoot()
    {
        canShoot = false;

        if(ammoSlot.GetCurrentAmmoAmount(ammoType) > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmoAmount(ammoType);
        }

        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();;
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else { return; }
    }

    void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1);
    }
}
