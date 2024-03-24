using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 10;

    public int GetCurrentAmmoAmount()
    {
        return ammoAmount;
    }

    public void ReduceCurrentAmmoAmount()
    {
        ammoAmount -= 1;
    }
}
