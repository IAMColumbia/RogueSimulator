using UnityEngine;

public class LogHandler : MonoBehaviour
{
    TriggerVolume volume;
    PlayerHealth health;
    bool isLogActive = false;
    [SerializeField] private Animator animator;
    private LootManager lootManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        volume = GetComponent<TriggerVolume>();
        lootManager = GetComponent<LootManager>();
        health = FindFirstObjectByType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isLogActive == true) isLogActive = false;
    }

    public void LogTriggered()
    {
        isLogActive = true;
        animator.SetTrigger("Activated");

        if (volume.isPlayerThere == true)
        {
            if (health == null)
            {
                Debug.LogError("No PlayerHealth component found.");
                return;
            }

            health.PlayerHit();
        }
        else
        {
            Debug.Log("No player to hit");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Something has entered the LogHandler's Collider");
        if (other.CompareTag("Enemy"))
        {
            if (isLogActive == true)
            {
                GameObject enemy = other.attachedRigidbody != null
                ? other.attachedRigidbody.gameObject
                : other.gameObject;
                EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
                enemyMovement.KillYourself(lootManager);
            }

        }
    }
}
