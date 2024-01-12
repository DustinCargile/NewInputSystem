using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerInputActions _input;
    
    private 

    // Start is called before the first frame update
    void Start()
    {
        _input = new PlayerInputActions();

        _input.Player.Enable();

        _input.Player.SwitchMaps.performed += SwitchMaps_performed;
        
    }

    private void SwitchMaps_performed(InputAction.CallbackContext context)
    {
        _input.Player.Disable();
        _input.Driving.Enable();
    }



    // Update is called once per frame
    void Update()
    {
        CalculateMovement();   
    }

    private void CalculateMovement() 
    {
        var move = _input.Player.Movement.ReadValue<Vector2>();
        var driveMove = _input.Driving.Movement.ReadValue<Vector2>();

        transform.Translate(new Vector3(move.x, 0, move.y) * Time.deltaTime * 5f);
        transform.Translate(new Vector3(driveMove.x, 0, driveMove.y) * Time.deltaTime * 30f);

    }
}
