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
        CalculateMovement();   
    }

    private void CalculateMovement() 
    {
        var move = _input.Player.Movement.ReadValue<Vector2>();

        transform.Translate(new Vector3(move.x, 0, move.y) * Time.deltaTime * 5f);
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
        Debug.Log("Object is Invisible!");
    }
}
