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

    void OnDisable() 
    {
        ZoomOut();    
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            ZoomIn();
        }
        if (Input.GetMouseButtonUp(1))
        {
            ZoomOut();
        }
    }

    private void ZoomIn()
    {
        camera.m_Lens.FieldOfView = ZoomFoV;
        fpsController.RotationSpeed = zoomSensitivity;
    }

    private void ZoomOut()
    {
        camera.m_Lens.FieldOfView = DefaultFoV;
        fpsController.RotationSpeed = defaultSensitivity;
    }
}
