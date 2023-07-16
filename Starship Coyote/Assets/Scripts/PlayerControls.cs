using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float moveSpeed = 45f;
    [SerializeField] float xRange = 50f;
    [SerializeField] float yRange = 20f;
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    void ProcessTranslation()
    {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

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
        float xRotation = -30f;
        float yRotation = 30f;
        float zRotation = 0f;

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, zRotation);
    }
}
