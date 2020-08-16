using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float angleRestore = 70f;
    [SerializeField] float intensityIncrease = 3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponentInChildren<FlashlightSystem>().RestoreLightAngle(angleRestore);
            other.gameObject.GetComponentInChildren<FlashlightSystem>().RestoreLightIntestity(intensityIncrease);

            Destroy(gameObject);
        }
    }
}
