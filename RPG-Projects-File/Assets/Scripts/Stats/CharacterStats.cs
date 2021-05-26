using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public Stats damage;
    public Stats armor;
    public int maxHealt = 100;
    public int currentHealt { get; private set; }

    private void Awake()
    {
        currentHealt = maxHealt;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage )
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealt -= damage;

        Debug.Log(transform.name + "takes" + damage + "damage");

        if (currentHealt <= 0)
            Die();
    }
    public virtual void Die()
    {
        Debug.Log(transform.name + "Died");
    }
}
