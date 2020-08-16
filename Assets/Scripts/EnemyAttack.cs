using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float damage = 6f;

    PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if (playerHealth)
        {
            playerHealth.Decrease(damage);
            playerHealth.GetComponent<DisplayDamage>().ShowDamageImpact();
        }
    }
}
