using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float moveSpeed = 40f;
    [SerializeField] float xRange = 48f;
    [SerializeField] float yRange = 22f;
    [SerializeField] float positionPitchFactor = -1.25f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = -40f;
    [SerializeField] float positionYawFactor = -0.005f;


    float xThrow;
    float yThrow;
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
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
}
