using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 50f;

    public void takeDamage(float damage)
    {
        hitPoints -= damage;

        if (hitPoints <= 0)
        {
            Destroy(gameObject);

            // todo: death effect
            // todo: factor out
        }
    }    
}
