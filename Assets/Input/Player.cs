using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerInputActions _input;

    private void Start()
    {
        _input = new PlayerInputActions();

        _input.Player.Enable();

        _input.Player.ShootBall.performed += ShootBall_performed;
    }

    private void ShootBall_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Debug.Log("Shoot Ball..." + context);
    }
}
