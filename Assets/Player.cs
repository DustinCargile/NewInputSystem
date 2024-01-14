using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame) 
        {
            Debug.Log("Space key was pressed!");
        }

        if (Mouse.current.leftButton.wasPressedThisFrame) 
        {
            Debug.Log("Left Click");
        }
    }
}