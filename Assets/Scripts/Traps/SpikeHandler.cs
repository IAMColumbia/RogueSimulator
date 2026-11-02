using UnityEngine;

public class SpikeHandler : MonoBehaviour
{
    private TriggerVolume volume;
    private PlayerHealth health;

    private TimerTrigger playerActivateTimer;
    private TimerTrigger deactivateTimer;
    private TimerTrigger enemyActivateTimer;

    public bool isSpikeActive = false;

    [SerializeField] private Animator animator;
    private LootManager lootManager;

    private void Awake()
    {
        volume = GetComponent<TriggerVolume>();
        health = FindFirstObjectByType<PlayerHealth>();
        lootManager = FindFirstObjectByType<LootManager>();

        TimerTrigger[] timers = GetComponents<TimerTrigger>();

        if (timers.Length >= 3)
        {
            playerActivateTimer = timers[0];
            deactivateTimer = timers[1];
            enemyActivateTimer = timers[2];
        }
        else
        {
            Debug.LogError(
                "SpikeHandler requires three TimerTrigger components.",
                this
            );
        }
    }

    public void PlayerTriggeredSpike()
    {
        if (isSpikeActive) return;
        Debug.Log("PlayerTriggeredSpike called!");
        isSpikeActive = true;
        animator.SetTrigger("Activated");

        if (volume != null && volume.isPlayerThere)
        {
            if (health == null)
                health = FindFirstObjectByType<PlayerHealth>();

            if (health != null)
                health.PlayerHit();
        }

        StartDeactivationTimer();
    }

    public void EnemyTriggeredSpike()
    {
        if (isSpikeActive) return;
        Debug.Log("EnemyTriggeredSpike called!");
        isSpikeActive = true;
        animator.SetTrigger("Activated");

        StartDeactivationTimer();
    }

    private void StartDeactivationTimer()
    {
        Debug.Log("dectivating spikes");
        if (deactivateTimer != null)
        {
            deactivateTimer.StopTimer();
            deactivateTimer.ResetTimer();
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
        if (other.CompareTag("Enemy")) Debug.Log("enemy in collider");
        if (other.CompareTag("Player")) Debug.Log("player in collider");
        if (!isSpikeActive)
        {
            return;
        }
        //Debug.Log("enemy should die");
        if (other.CompareTag("Enemy"))
        {
            EnemyMovement enemyMovement =
                other.GetComponentInParent<EnemyMovement>();

            if (enemyMovement != null)
            {
                enemyMovement.KillYourself(lootManager);
            }
        }
    }
}