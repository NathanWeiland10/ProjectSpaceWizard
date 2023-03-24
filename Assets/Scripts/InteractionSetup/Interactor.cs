using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField]
    private Transform _interactionPoint;

    [SerializeField]
    private float _interactionPointRadius = 0.5f;

    [SerializeField]
    private LayerMask _interactableMask;

    private readonly Collider[] _colliders = new Collider[3];

    [SerializeField]
    private int _numFound;


    

    /// <summary>
    /// every frame, check for overlap for interaction
    /// https://www.youtube.com/watch?v=THmW4YolDok
    /// </summary>
    private void Update()
    {
        
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);

        if(_numFound > 0){
            var interactable = _colliders[0].GetComponent<IInteractable>();

            if(interactable != null && Keyboard.current.eKey.wasPressedThisFrame){
                interactable.Interact(this);
            }
        }
    }

    ///<summary> in editor gizmo visual </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }



}
