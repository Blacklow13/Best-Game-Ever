using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float Speed ;
    public float lifetime ;
    public float damage = 10 ;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyFireball", lifetime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveFixedUpdate();
    }
    private void MoveFixedUpdate()
    {
        transform.position += (transform.forward * Speed * Time.fixedDeltaTime);
    }
    void Update()
    {
    }
    void OnCollisionEnter(Collision collision)
    {
        DestroyFireball();
        DamageEnemy(collision);
        

    }
    private void DamageEnemy(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.value -= damage;
            if (enemyHealth.value <= 0)
            {
                Destroy(enemyHealth.gameObject);
            }
        }
    }
    private void DestroyFireball()
    {
        Destroy(gameObject);
    }

    }
