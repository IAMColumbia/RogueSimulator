
using UnityEngine;

public class LogHandler : MonoBehaviour
{
    private TriggerVolume volume;
    private PlayerHealth health;
    private TimerTrigger deactivateTimer;
    private LootManager lootManager;

    public bool isLogActive = false;

    [SerializeField] private Animator animator;

    private void Awake()
    {
        volume = GetComponent<TriggerVolume>();
        health = FindFirstObjectByType<PlayerHealth>();
        lootManager = FindFirstObjectByType<LootManager>();

        deactivateTimer = GetComponent<TimerTrigger>();

        if (deactivateTimer == null)
        {
            Debug.LogError(
                "LogHandler requires a TimerTrigger component.",
                this
            );
        }
    }

    public void LogTriggered()
    {
        if (isLogActive) return;

        Debug.Log("LogTriggered called!");

        isLogActive = true;
        animator.SetTrigger("Activated");

        // Damage the player if they are inside the trigger volume.
        if (volume != null && volume.isPlayerThere)
        {
            if (health == null)
                health = FindFirstObjectByType<PlayerHealth>();

            if (health != null)
                health.PlayerHit();
            else
                Debug.LogError("No PlayerHealth component found.");
        }

        StartDeactivationTimer();
    }

    private void StartDeactivationTimer()
    {
        Debug.Log("Starting log deactivation timer.");

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

    public void DeactivateLog()
    {
        Debug.Log("Log deactivated.");
        isLogActive = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!isLogActive) return;

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy inside active log collider.");

            EnemyMovement enemyMovement =
                other.GetComponentInParent<EnemyMovement>();

            if (enemyMovement != null)
            {
                enemyMovement.KillYourself(lootManager);
            }
        }
    }
}
