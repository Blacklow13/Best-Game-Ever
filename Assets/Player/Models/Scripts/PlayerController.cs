using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = 9.8f;
    public float jumpForce;
    public float speed;

    public Animator animator;

    private float _fallVelocity = 0;
    private CharacterController _characterController;
    private Vector3 _moveVector;
    private int jump = 0 ;

    void OnEnable()
    {
        _characterController = GetComponent<CharacterController>();
    }
    void Update ()
    {
        Movement();
        Jump();


    }
    private void Movement()
    {


        _moveVector = Vector3.zero;

        var runDirection = 0;

        if (Input.GetKey(KeyCode.W) )
        {
            _moveVector += transform.forward;
            runDirection = 1;
        }
        if (Input.GetKey(KeyCode.S) )
        {
            _moveVector -= transform.forward;
            runDirection = 2;
        }
        if (Input.GetKey(KeyCode.A)  )
        {
            _moveVector -= transform.right;
            runDirection = 4;
        }
        if (Input.GetKey(KeyCode.D) )
        {
            _moveVector += transform.right;
            runDirection = 3;


        }

        animator.SetInteger("run_direction", runDirection);
    }

    private void Jump()
    {

        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
            jump = 1;

        }
        if (_characterController.isGrounded == false) 
        {
            jump = 0;

        }

        animator.SetInteger("jump", jump);
    }



    void FixedUpdate()
    {

        _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);


        // Fall and Jump
        _fallVelocity += gravity * Time.fixedDeltaTime;

        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
        if (_characterController.isGrounded)
        { 
            _fallVelocity = 0;
        }
    }
}
