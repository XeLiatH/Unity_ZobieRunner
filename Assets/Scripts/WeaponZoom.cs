using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFov = 30f;

    bool zoomedIn = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomedIn)
            {
                fpsCamera.fieldOfView = zoomedOutFOV;
            }
            else
            {
                fpsCamera.fieldOfView = zoomedInFov;
            }

            zoomedIn = !zoomedIn;
        }
    }
}
