using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] float ZoomFoV = 20;
    [SerializeField] float DefaultFoV = 40;
    [SerializeField] new CinemachineVirtualCamera camera;



    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            camera.m_Lens.FieldOfView = ZoomFoV;
        }
        if(Input.GetMouseButtonUp(1))
        {
            camera.m_Lens.FieldOfView = DefaultFoV;
        }
    }
}
