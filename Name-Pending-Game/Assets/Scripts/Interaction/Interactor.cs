using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;

    private readonly Collider2D[] _collidders = new Collider2D[3];
    [SerializeField] private int _numFound;

    [SerializeField] private int powerCellsAcquired;
                                                                                
    private void Update()
    {
        _numFound = Physics2D.OverlapCircleNonAlloc(_interactionPoint.position, _interactionPointRadius, _collidders, (int)_interactableMask);

        if (_numFound > 0)
        {
            var interactable = _collidders[0].GetComponent<IInteractable>();

            if (interactable != null && Input.GetButtonDown("Interact"))
            {
                powerCellsAcquired = interactable.Interact(this, powerCellsAcquired);
                interactable.ElevatorMove();
            }
            Debug.Log(powerCellsAcquired);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}

