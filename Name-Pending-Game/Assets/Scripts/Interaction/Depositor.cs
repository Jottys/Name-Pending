using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Depositor : MonoBehaviour, IInteractable
{
    public string InteractionPrompt { get; }

    public int Interact(Interactor interactor, int powerCellsAcquired)
    {
        if (powerCellsAcquired > 0)
        {
            powerCellsAcquired--;
            Debug.Log("Delivering PowerCell");
            DoTheThing();
        }
        else
        {
            Debug.Log("Not enough PowerCells");
        }

        return powerCellsAcquired;
    }

    public void ElevatorMove()
    {
    }

    private void DoTheThing()
    {

    }
}
