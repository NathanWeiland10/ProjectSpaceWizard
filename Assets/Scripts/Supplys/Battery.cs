using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour, IInteractable
{
    [SerializeField]
    private string _prompt;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor){
        Debug.Log("Picking up battery!");
        // do more stuff here

        Destroy(this.gameObject);
        return true;
    }
}
