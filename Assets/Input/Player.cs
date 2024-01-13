using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerInputActions _input;

    private Rigidbody _rb;
    private bool _isPressed = false;
    private float _force = 0;

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
        if (_rb != null)
        {

            _rb.AddForce(Vector3.up * _force, ForceMode.Impulse);
        }
        _force = 0;
        _isPressed = false;
    }

    private void ShootBall_performed(InputAction.CallbackContext context)
    {
        _isPressed = true;

    }

    private void Update()
    {

        if (_isPressed) 
        {
            _force += Time.deltaTime * 10f;
        }

    }




}
