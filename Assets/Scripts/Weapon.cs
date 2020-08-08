using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float bulletDamage = 5f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        bool isHit = Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out RaycastHit hit, range);
        if (isHit)
        {
            Debug.Log(hit.transform.name);

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target)
            {
                target.takeDamage(bulletDamage);
            }

            // todo: add visual effect
        }
    }
}
