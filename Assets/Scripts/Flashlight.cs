using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Flashlight : MonoBehaviour
{

    [SerializeField] private GameObject light;

    private float _batteryHealth = 100.0f;

    private bool _isEquipped = true;


    // Start is called before the first frame update
    void Start()
    {
        light.SetActive(false);
    }

    void Update() 
    {
        if (Keyboard.current.fKey.wasPressedThisFrame && _batteryHealth > 0 && _isEquipped) {
            light.SetActive(!light.activeSelf);
        }   

        if (light.activeSelf && _batteryHealth > 0 && _isEquipped) {
            _batteryHealth -= .001f;
            Debug.Log(_batteryHealth);
        }
    }

    public float GetBatteryHealth() 
    {
        return _batteryHealth;
    }

    public void SetBatteryHealth(float newHealth)
    {
        _batteryHealth = Mathf.Min(_batteryHealth + newHealth, 100); 
    }


}