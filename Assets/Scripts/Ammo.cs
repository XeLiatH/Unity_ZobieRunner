using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int amount = 50;

    public int GetCurrentAmount()
    {
        return amount;
    }

    public void DecreaseAmmo()
    {
        amount--;
    }
}
