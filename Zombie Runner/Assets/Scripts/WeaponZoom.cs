using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    
    [SerializeField] new CinemachineVirtualCamera camera;
    [SerializeField] FirstPersonController fpsController;
    [SerializeField] float ZoomFoV = 20;
    [SerializeField] float DefaultFoV = 40;
    [SerializeField] float defaultSensitivity = 1f;
    [SerializeField] float zoomSensitivity = .6f;

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            camera.m_Lens.FieldOfView = ZoomFoV;
            fpsController.RotationSpeed = zoomSensitivity;
        }
        if(Input.GetMouseButtonUp(1))
        {
            camera.m_Lens.FieldOfView = DefaultFoV;
            fpsController.RotationSpeed = defaultSensitivity;
        }
    }
}
