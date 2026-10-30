
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 2f;

    private bool isAggro = false;
    private PlayerHealth health;

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            health = player.GetComponent<PlayerHealth>();
        }
    }

    void Update()
    {
        if (player != null && isAggro == true)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (health == null)
                health = collision.gameObject.GetComponent<PlayerHealth>();

            if (health != null)
                health.PlayerHit();
            else
                Debug.LogError("PlayerHealth component not found on Player.");
        }
    }

    public void KillYourself(LootManager lootmanager)
    {
        if (lootmanager == null)
        {
            lootmanager = GameObject.Find("LootManager").GetComponent<LootManager>();
        }

        lootmanager.SpawnLootOnDeath(gameObject);
        Destroy(gameObject);
    }

    public void TurnAggro()
    {
        isAggro = true;
    }
}
