using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100;
    
    public PlayerProgress playerProgress;

    private bool IsKilled = true;
   
    public bool IsAlive()
    {
        return value > 0;

    }

    void Start()
    {
        
    }
    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0  && IsKilled )
        {
            playerProgress.AddKils();
            Destroy(gameObject);
            IsKilled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
