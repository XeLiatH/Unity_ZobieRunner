using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float bulletDamage = 5f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        ProcessRaycast();
        PlayMuzzleFlash();
    }

    private void ProcessRaycast()
    {
        bool isHit = Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out RaycastHit hit, range);
        if (isHit)
        {
            HitImpact(hit);

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target)
            {
                target.takeDamage(bulletDamage);
            }
        }
    }

    private void HitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }
}
