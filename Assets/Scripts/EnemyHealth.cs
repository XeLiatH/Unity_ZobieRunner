using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 50f;

    Animator animator;

    bool isDead = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void Decrease(float damage)
    {
        BroadcastMessage("OnDamageTaken");

        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) { return; }

        isDead = true;
        animator.SetTrigger("death");
    }
}
