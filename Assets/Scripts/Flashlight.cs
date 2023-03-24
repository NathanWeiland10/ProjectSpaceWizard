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
        if (Keyboard.current.fKey.wasPressedThisFrame && _batteryHealth > 0) {
            light.SetActive(!IsActive(light));
            StartCoroutine(DecreaseBattery());
        }   
    }

    // Update is called once per frame
    // void FixedUpdate()
    // {
    //     if (light.activeSelf) {
    //         _batteryHealth -= 0.005f;
    //         Debug.Log(_batteryHealth);  
    //     }
    // }

    IEnumerator DecreaseBattery()
    {
        //for (float alpha = _batteryHealth; alpha >= 0f; alpha -= 1f) {
            _batteryHealth -= 1f;
            Debug.Log(_batteryHealth);
            yield return new WaitForSeconds(1f);

            if (light.activeSelf && _batteryHealth > 0) {
               StartCoroutine(DecreaseBattery());  
            }
        //}
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