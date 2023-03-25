using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Flashlight : MonoBehaviour
{

    [SerializeField] private GameObject _light;

    [SerializeField] private float _batteryHealth = 100.0f;

    private bool _isEquipped = true;

    private GameObject _batteryIndicator;

    private Slider _batterySlider;

    private GameObject _batteryColor;

    private Image _batteryColorImage;

    [SerializeField] private float BatteryDelta = 0.001f;

    void Awake()
    {
        _light.SetActive(false);

        _batteryIndicator = GameObject.FindWithTag("BatteryIndicator");
        _batterySlider = _batteryIndicator.GetComponent<Slider>();

        _batteryColor = GameObject.FindWithTag("BatteryColor");
        _batteryColorImage = _batteryColor.GetComponent<Image>();

        
    }

    void Update() 
    {
        if (_batteryHealth <= 0) {
            _light.SetActive(false);
        }

        if (Keyboard.current.fKey.wasPressedThisFrame && _batteryHealth > 0 && _isEquipped) {
            _light.SetActive(!_light.activeSelf);
        }   

        if (_light.activeSelf && _batteryHealth > 0 && _isEquipped) {
            _batteryHealth -= BatteryDelta;
            _batterySlider.value = (_batteryHealth / 100);

            _batteryColorImage.color = Color.Lerp(Color.red, Color.green, _batterySlider.value);
        }
    }

    public float GetBatteryHealth() 
    {
        return _batteryHealth;
    }

    public void SetBatteryHealth(float newHealth)
    {
        _batteryHealth = Mathf.Min(_batteryHealth + newHealth, 100.0f);
        _batterySlider.value = Mathf.Min(_batterySlider.value + (newHealth/100.0f), 1.0f);
        _batteryColorImage.color = Color.Lerp(Color.red, Color.green, _batterySlider.value);
    }


}