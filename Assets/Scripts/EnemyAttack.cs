using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float damage = 6f;

    void Start()
    {
        
    }

    public void AttackHitEvent()
    {
        if (target == null) { return; }

        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
        if (playerHealth)
        {
            playerHealth.Decrease(damage);
        }
    }
}
