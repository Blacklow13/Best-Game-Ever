using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    public float delay = 3;
    public GameObject explosionPrefab;
     // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision) 
    {
        Invoke("Explosion", delay);
    
    }
    private void Explosion()
    {
        Destroy(gameObject);
        var explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
