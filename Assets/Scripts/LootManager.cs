using UnityEngine;

public class LootManager : MonoBehaviour
{
    [SerializeField] private GameObject lootDrop;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnLootOnDeath(GameObject deadEnemy)
    {
        Instantiate(lootDrop, deadEnemy.transform.position, deadEnemy.transform.rotation);
    }
}
