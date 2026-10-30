using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 2f;
    private bool isAggro = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (player != null && isAggro == true)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
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
