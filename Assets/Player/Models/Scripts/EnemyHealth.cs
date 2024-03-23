using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100;
    
    public PlayerProgress playerProgress;

    void Start()
    {
        
    }
    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0)
        {
            playerProgress.AddKils();
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
