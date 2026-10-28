using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Fires an event when the player enters the trigger volume.
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class TriggerVolume : MonoBehaviour
{
    [SerializeField] private UnityEvent playerEnteredTriggerVolume;
    [SerializeField] private bool canBeTriggeredMultipleTimes = false;
    public bool isPlayerThere = false;

    private bool triggered;
    
    // called in edit mode when this component is first added to a gameobject.
    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (triggered && !canBeTriggeredMultipleTimes) return;

        triggered = true;
        playerEnteredTriggerVolume?.Invoke();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")) isPlayerThere = true;
    }

    private void OnTriggerExit2D (Collider2D other)
    {
        if (other.CompareTag("Player")) isPlayerThere = false;
    }
}