using UnityEngine;

public class BoulderHandler : MonoBehaviour
{
    RayTrigger rayTrigger;
    PlayerHealth health;
    bool isBoulderActive = false;
    private LootManager lootManager;
    //bool PlayerIsThere = false;
    //bool EnemyIsThere = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rayTrigger = GetComponent<RayTrigger>();
        health = FindFirstObjectByType<PlayerHealth>();
        lootManager = GetComponent<LootManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBoulderActive)
        {
            transform.Translate(Vector2.down * Time.deltaTime * 5f);
        }

    }

    public void BoulderTriggered()
    {
        isBoulderActive = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Loot"))
        {
            return;
        }
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy has entered the Boulder's Collider");
            if (isBoulderActive == true)
            {
                GameObject enemy = other.attachedRigidbody != null
                ? other.attachedRigidbody.gameObject
                : other.gameObject;
                EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
                enemyMovement.KillYourself(lootManager);
            }

        }
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has entered the Boulder's Collider");
            if (isBoulderActive == true)
            {
                if (health == null)
                {
                    Debug.LogError("No PlayerHealth component found.");
                    return;
                }
                health.PlayerHit();
            }
        }
    }
}
