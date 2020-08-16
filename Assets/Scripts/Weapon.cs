using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] TextMeshProUGUI ammoText;

    bool hasShot = false;

    void Update()
    {
        DisplayAmmo();
        if (Input.GetMouseButtonDown(0) && !hasShot)
        {
            StartCoroutine(Shoot());
        }
    }

    private void OnEnable()
    {
        hasShot = false;
    }

    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmount(ammoType);
        ammoText.text = currentAmmo.ToString();
    }

    private IEnumerator Shoot()
    {
        hasShot = true;
        if (CanShoot())
        {
            ProcessRaycast();
            PlayMuzzleFlash();
            ammoSlot.DecreaseAmmo(ammoType);
        }

        yield return new WaitForSeconds(shootingDelay);
        hasShot = false;
    }

    private bool CanShoot()
    {
        return ammoSlot.GetCurrentAmount(ammoType) > 0;
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
