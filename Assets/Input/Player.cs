using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerInputActions _input;

    private Rigidbody _rb;

    private bool _hasJumped = false;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _input = new PlayerInputActions();

        _input.Player.Enable();

        _input.Player.ShootBall.performed += ShootBall_performed;
        _input.Player.ShootBall.canceled += ShootBall_canceled;
    }

    private void ShootBall_canceled(InputAction.CallbackContext context)
    {
        var force = (float)context.duration;
        if (_rb != null && !_hasJumped)
        {

            _rb.AddForce(Vector3.up * Mathf.Clamp(force * 10f, 0f, 10f) , ForceMode.Impulse);
            
        }
        _hasJumped=true;
    }

    private void ShootBall_performed(InputAction.CallbackContext context)
    {
        if (_rb != null && !_hasJumped)
        {

            _rb.AddForce(Vector3.up * 10f, ForceMode.Impulse);
            
        }
        _hasJumped = true;
    }

    private void Update()
    {

       

    }
    private void OnCollisionEnter(Collision collision)
    {
        
        _hasJumped = false;  
    }

   



}
