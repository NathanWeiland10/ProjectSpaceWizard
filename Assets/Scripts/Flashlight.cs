using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Flashlight : MonoBehaviour
{

    [SerializeField] private GameObject light;

    private float _batteryHealth = 100.0f;


    // Start is called before the first frame update
    void Start()
    {
        light.SetActive(false);
    }

    void Update() 
    {
       if (Keyboard.current.fKey.wasPressedThisFrame) {
            light.SetActive(!IsActive(light));
        }   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (light.activeSelf) {
            _batteryHealth -= 0.005f;
            Debug.Log(_batteryHealth);  
        }
    }

    public bool IsActive(GameObject light)
    {
        if (light.activeSelf == true)
        {
            return true;
        } 
        else
        {
            return false;
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