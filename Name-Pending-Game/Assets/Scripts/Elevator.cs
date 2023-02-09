using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour, IInteractable
{
    
    [SerializeField] private List<GameObject> _stations;
    [SerializeField] private bool atShip;

    public string InteractionPrompt { get; }

    public void ElevatorMove()
    {

        if (this.gameObject == _stations[0])
        {
            atShip = true;
        }
        else
        {
            atShip = false;
        }

        if (atShip)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = _stations[1].transform.position;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = _stations[0].transform.position;
        }
            
    }

    public int Interact(Interactor interactor, int powerCellsAcquired)
    {
        return powerCellsAcquired;
    }
}
