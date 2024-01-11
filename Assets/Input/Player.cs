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

        _input.Player.ChangeColor.performed += ChangeColor_performed;
    }

    private void ChangeColor_performed(InputAction.CallbackContext context)
    {
        Material mat = GetComponent<MeshRenderer>().material;
        mat.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
