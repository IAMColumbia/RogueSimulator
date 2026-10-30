
using UnityEngine;

public class SpikeHandler : MonoBehaviour
{
    private TriggerVolume volume;
    private PlayerHealth health;
    private TimerTrigger activateTimer;
    private TimerTrigger deactivateTimer;

    public bool isSpikeActive = false;

    [SerializeField] private Animator animator;

    //[Tooltip("How long the spikes remain dangerous.")]
    //[SerializeField] private float activeDuration = 0.5f;
    private LootManager lootManager;


    private void Awake()
    {
        volume = GetComponent<TriggerVolume>();
        health = FindFirstObjectByType<PlayerHealth>();
        lootManager = FindFirstObjectByType<LootManager>();

        TimerTrigger[] timers = GetComponents<TimerTrigger>();

        if (timers.Length >= 2)
        {
            activateTimer = timers[0];
            deactivateTimer = timers[1];
        }
        else
        {
            Debug.LogError(
                "SpikeHandler requires two TimerTrigger components.",
                this
            );
        }
    }

    public void SpikeTriggered()
    {
        if (isSpikeActive) return;

        isSpikeActive = true;
        animator.SetTrigger("Activated");

        if (volume != null && volume.isPlayerThere)
        {
            if (health == null)
                health = FindFirstObjectByType<PlayerHealth>();

            if (health != null)
                health.PlayerHit();
            else
                Debug.LogError("No PlayerHealth component found.");
        }

        if (deactivateTimer != null)
        {
            deactivateTimer.StopTimer();
            deactivateTimer.StartTimer();
        }
        else
        {
            Debug.LogError("Deactivate TimerTrigger is not assigned.");
        }
    }

    public void DeactivateSpikes()
    {
        isSpikeActive = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!isSpikeActive) return;

        if (other.CompareTag("Enemy"))
        {
            GameObject enemy = other.attachedRigidbody != null
                ? other.attachedRigidbody.gameObject
                : other.gameObject;
            lootManager.SpawnLootOnDeath(enemy);
            Destroy(enemy);
        }
    }
}
