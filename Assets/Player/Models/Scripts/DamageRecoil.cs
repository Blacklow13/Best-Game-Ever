using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageRecoil : MonoBehaviour
{
    public float FloatingDistance;

    public int IterationsOfRecoil;

    private int IterationCount;

    private bool isPlayerGetsRecoil_;

    private Vector3 start_pos;

    public float Speed;

    private bool a = true;

    void Start()
    {
        start_pos = transform.position;
    }
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) && isPlayerGetsRecoil_ )
        {
            isPlayerGetsRecoil_ = true;
            if (transform.position.y - start_pos.y <= -FloatingDistance)
            {
                a = true;

                IterationCount++;
            }
            if (transform.position.y - start_pos.y >= FloatingDistance)
            {
                a = false;

                IterationCount++;
            }
            if (a && transform.position.y - start_pos.y < FloatingDistance)
            {
                transform.position += transform.up * Speed * Time.fixedDeltaTime;
            }
            else
            {
                transform.position -= transform.up * Speed * Time.fixedDeltaTime;

            }
            if (IterationCount >= IterationsOfRecoil)
            {
                isPlayerGetsRecoil_ = false;
                IterationCount = 0;
            }
        }
    }
  

}
