using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Fires an event when the player enters the trigger volume.
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class TriggerVolume : MonoBehaviour
{
    [SerializeField] private UnityEvent playerEnteredTriggerVolume;
    [SerializeField] private UnityEvent enemyEnteredTriggerVolume;
    [SerializeField] private bool canBeTriggeredMultipleTimes = false;
    public bool isPlayerThere = false;

    [SerializeField] private bool triggered;

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
        if (!other.CompareTag("Player") && !other.CompareTag("Enemy")) return;
        if (triggered && !canBeTriggeredMultipleTimes) return;
        if (other.CompareTag("Player")) PlayerEntered();
        if (other.CompareTag("Enemy")) EnemyEntered();
        triggered = true;

    }

    private void PlayerEntered()
    {
        playerEnteredTriggerVolume?.Invoke();
    }
    private void EnemyEntered()
    {
        enemyEnteredTriggerVolume?.Invoke();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy")) isPlayerThere = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy")) isPlayerThere = false;
    }
}