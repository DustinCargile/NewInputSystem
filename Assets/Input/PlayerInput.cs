using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{

    //get a reference and start an instance of our input actions

    //Enable Input Action Map (dog)

    //Register perform functions

    private PlayerInputActions _input;

    private void Start()
    {
        _input = new PlayerInputActions();
        _input.Dog.Enable();

        _input.Dog.Bark.performed += Bark_performed;
        _input.Dog.Bark.canceled += Bark_canceled;
        _input.Dog.Bark.started += Bark_started;
    }

    private void Bark_started(InputAction.CallbackContext context)
    {
        Debug.Log("Started Barking!");
    }

    private void Bark_canceled(InputAction.CallbackContext context)
    {
        Debug.Log("Done Barking!");
    }

    private void Bark_performed(InputAction.CallbackContext context)
    {
        Debug.Log("Bark!!!" + context);
    }

    private void OnDisable()
    {
        _input.Dog.Bark.performed -= Bark_performed;
        _input.Dog.Bark.canceled -= Bark_canceled;
        _input.Dog.Bark.started -= Bark_started;
    }
}
