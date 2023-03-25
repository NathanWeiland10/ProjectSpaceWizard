using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFactory
{
    private Color _batteryRed = new Color(1.0f, 0.0f, 0.0f, 1.0f);

    private Color _batteryOrange = new Color(1.0f, 0.5f, 0.0f, 1.0f);

    private Color _batteryGreen = new Color(47.0f/255.0f, 150.0f/255.0f, 9.0f/255.0f, 1.0f);

    private Color _batteryYellow = new Color(1.0f, 1.0f, 0.0f, 1.0f);

    private float _time;

    public ColorFactory() {
        this._time = 0.0f;
    }

    public ColorFactory(float time) {
        this._time = time;
    }

    public Color GetBatteryLerp() {
        if (_time > 75.0f) {
            return Color.Lerp(_batteryYellow, _batteryGreen, _time/ 100.0f);
        } else if (_time > 50.0f) {
            return Color.Lerp(_batteryOrange, _batteryYellow, _time / 100.0f);
        } else {
            return Color.Lerp(_batteryRed, _batteryOrange, _time / 100.0f);
        }
    }

    public void SetTime(float time) {
        this._time = time;
    }

}
