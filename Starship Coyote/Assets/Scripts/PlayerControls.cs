using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("General Setup Settings")]
    [Tooltip("How fast the ship moves")] [SerializeField] float moveSpeed = 40f;
    [Tooltip("How far the ship can move left/right")] 
    [SerializeField] float xRange = 35f;
    [Tooltip("How far the ship can move up/down")] 
    [SerializeField] float yRange = 17f;

    [Header("Laser Gun Array")]
    [Tooltip("An array of lasers")] [SerializeField] GameObject[] lasers;

    [Header("Screen Position Based Tuning")]
    [Tooltip("How much the ship pitches based on position")] 
    [SerializeField] float positionPitchFactor = -1.25f;
    [Tooltip("The ship yaw based on position")] 
    [SerializeField] float positionYawFactor = 1f;

    [Header("Player Input Based Tuning")]
    [Tooltip("How much the ship pitches based on input")] 
    [SerializeField] float controlPitchFactor = -20f;
    [Tooltip("How much the ship rolls based on input")] 
    [SerializeField] float controlRollFactor = -40f;


    float xThrow;
    float yThrow;
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * moveSpeed;
        float yOffset = yThrow * Time.deltaTime * moveSpeed;

        float xPos = transform.localPosition.x + xOffset;
        float yPos = transform.localPosition.y + yOffset;

        float clampXPos = Mathf.Clamp(xPos, -xRange, xRange);
        float clampYPos = Mathf.Clamp(yPos, -yRange, yRange + 2);

        float zPos = transform.localPosition.z;
        transform.localPosition = new Vector3(clampXPos, clampYPos, zPos);
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float xPitch = pitchDueToPosition + pitchDueToControlThrow;

        float yYaw = transform.localPosition.x * positionYawFactor;
        float zRoll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(xPitch, yYaw, zRoll);
    }

    void ProcessFiring()
    {
        if(Input.GetButton("Fire1"))
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
    }

    void SetLasersActive(bool isActive)
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }
}
