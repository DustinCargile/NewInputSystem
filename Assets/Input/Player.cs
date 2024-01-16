using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float _progress = 0;
    [SerializeField]
    private TextMeshProUGUI _progressText;
    [SerializeField]
    private Slider _progressSlider;

    [SerializeField]
    private TextMeshProUGUI _notificationText;

    private UIInputActions _input;

    private float _multiplier = -1;

    private float _speed = 1f;

    private int _frameCount = 0;
    private bool _moving = false;

    private int _chargingSpeed = 20;

    

    // Start is called before the first frame update
    void Start()
    {
        _input = new UIInputActions();
        _input.Player.Enable();

        _input.Player.Charge.performed += Charge_performed;
        _input.Player.Charge.canceled += Charge_canceled;
    }

    private void Charge_canceled(InputAction.CallbackContext context)
    {
        _multiplier = -1;
        _speed = 2f;

        _moving = true;
        _notificationText.text = "Losing Charge...";
        _chargingSpeed = 20;
    }

    private void Charge_performed(InputAction.CallbackContext context)
    {
        _multiplier = 1;
        _speed = 10f;
        _notificationText.text = "Charging...";
        _moving = true;
        _chargingSpeed = 40;
    }

    // Update is called once per frame
    void Update()
    {

        _frameCount++;

        FlashText();
        
        _progress += Time.deltaTime * _multiplier * _speed;
        

        CheckProgress();

        _progressSlider.value = _progress;
        _progressText.text = ((int)_progress).ToString();   

      
        
    }

    private void ToggleComponent(GameObject obj) 
    {
        if (obj.activeSelf)
        {
            obj.SetActive(false);
        }
        else 
        {
            obj.SetActive(true);
        }
    }

    private void FlashText() 
    {
        if (_frameCount % _chargingSpeed == 0 && _moving)
        {
            ToggleComponent(_notificationText.gameObject);
            _frameCount = 0;
        }
        if (!_moving)
        {
            _notificationText.gameObject.SetActive(true);
        }
    }
    private void CheckProgress() 
    {
        if (_progress <= 0)
        {
            _progress = 0;
            _notificationText.text = "No Charge!";
            _moving = false;
        }
        if (_progress >= 100)
        {
            _notificationText.text = "Fully Charged!";
            _progress = 100;
            _moving = false;
        }
    }
}
