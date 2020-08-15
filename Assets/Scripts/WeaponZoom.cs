using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] RigidbodyFirstPersonController fpsController;

    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFov = 30f;
    [SerializeField] float zoomedOutSensitivity = 2f;
    [SerializeField] float zoomedInSensitivity = 1f;

    bool zoomedIn = false;

    private void OnDisable()
    {
        ZoomOut();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomedIn)
            {
                ZoomOut();
            }
            else
            {
                ZoomIn();
            }

            zoomedIn = !zoomedIn;
        }
    }

    private void ZoomOut()
    {
        fpsCamera.fieldOfView = zoomedOutFOV;
        fpsController.mouseLook.XSensitivity = zoomedOutSensitivity;
        fpsController.mouseLook.YSensitivity = zoomedOutSensitivity;
    }

    private void ZoomIn()
    {
        fpsCamera.fieldOfView = zoomedInFov;
        fpsController.mouseLook.XSensitivity = zoomedInSensitivity;
        fpsController.mouseLook.YSensitivity = zoomedInSensitivity;
    }
}
