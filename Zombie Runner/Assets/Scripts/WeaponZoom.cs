using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] float ZoomFoV = 20;
    [SerializeField] float DefaultFoV = 40;
    [SerializeField] new CinemachineVirtualCamera camera;
    [SerializeField] float defaultSensitivity = 1f;
    [SerializeField] float zoomSensitivity = .6f;

    FirstPersonController firstPersonController;

    void Start()
    {
        firstPersonController = GetComponent<FirstPersonController>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            camera.m_Lens.FieldOfView = ZoomFoV;
            firstPersonController.RotationSpeed = zoomSensitivity;
        }
        if(Input.GetMouseButtonUp(1))
        {
            camera.m_Lens.FieldOfView = DefaultFoV;
            firstPersonController.RotationSpeed = defaultSensitivity;
        }
    }
}
