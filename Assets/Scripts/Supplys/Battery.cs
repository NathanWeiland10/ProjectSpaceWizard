using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour, IInteractable
{
    [SerializeField]
    private string _prompt;

    private Flashlight flashLight;

    public string InteractionPrompt => _prompt;

    void Awake()
    {
        flashLight = FindObjectOfType<Flashlight>();
    }

    public bool Interact(Interactor interactor){
        Debug.Log("Picking up battery!");
        // do more stuff here

        flashLight.SetBatteryHealth(25);

        Destroy(this.gameObject);
        return true;
    }
}
