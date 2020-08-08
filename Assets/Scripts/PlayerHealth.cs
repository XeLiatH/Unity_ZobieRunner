using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 130f;
 
    public void Decrease(float damage)
    {
        hitPoints -= damage;

        if (hitPoints <= 0)
        {
            Debug.Log("I am very much dead");
        }
    }
}
