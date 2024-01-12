using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerInputActions _input;
    // Start is called before the first frame update
    void Start()
    {
        _input = new PlayerInputActions();
        _input.Player.Enable();

      
    }

    

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,_input.Player.Rotate.ReadValue<float>()) * Time.deltaTime * 30f);  
    }
}
