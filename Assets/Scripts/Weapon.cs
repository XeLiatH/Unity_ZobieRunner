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
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float shootingDelay = 1f;

    bool hasShot = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !hasShot)
        {
            StartCoroutine(Shoot());
        }
    }

    private void OnEnable()
    {
        hasShot = false;
    }

    private IEnumerator Shoot()
    {
        hasShot = true;
        if (CanShoot())
        {
            ProcessRaycast();
            PlayMuzzleFlash();
            ammoSlot.DecreaseAmmo();
        }

        yield return new WaitForSeconds(shootingDelay);
        hasShot = false;
    }

    private bool CanShoot()
    {
        return ammoSlot.GetCurrentAmount() > 0;
    }

    private void ProcessRaycast()
    {
        bool isHit = Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out RaycastHit hit, range);
        if (isHit)
        {
            HitImpact(hit);

            EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
            if (enemyHealth)
            {
                enemyHealth.Decrease(bulletDamage);
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
