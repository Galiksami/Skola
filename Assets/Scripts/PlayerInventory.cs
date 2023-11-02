using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfBrains {  get; private set; }

    public UnityEvent<PlayerInventory> OnBrainsCollected;


    public void BrainCollected () 
    {
        NumberOfBrains++;
        OnBrainsCollected.Invoke(this);
    }
}
