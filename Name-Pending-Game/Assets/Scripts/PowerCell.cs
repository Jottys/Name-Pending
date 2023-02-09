using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCell : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

    public void ElevatorMove()
    {
    }


    public int Interact(Interactor interactor, int powerCellsAcquired)
    {
        if (powerCellsAcquired < 3)
        {
            powerCellsAcquired++;
        }
        Debug.Log("PowerCell Acuired");
        return powerCellsAcquired;
    }

}
