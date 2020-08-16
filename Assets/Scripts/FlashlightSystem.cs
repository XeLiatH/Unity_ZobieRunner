using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = 0.1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minAngle = 40f;

    Light myLight;

    void Start()
    {
        myLight = GetComponent<Light>();
    }

    void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntesity();
    }

    public void RestoreLightAngle(float restoreAngle)
    {
        myLight.spotAngle = restoreAngle;
    }

    public void RestoreLightIntestity(float intesityAmount)
    {
        myLight.intensity += intesityAmount;
    }

    private void DecreaseLightAngle()
    {
        if (myLight.spotAngle <= minAngle) { return; }
        myLight.spotAngle -= angleDecay * Time.deltaTime;
    }    

    private void DecreaseLightIntesity()
    {
        myLight.intensity -= lightDecay * Time.deltaTime;
    }
}
