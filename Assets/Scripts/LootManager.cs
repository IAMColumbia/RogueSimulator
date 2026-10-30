using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> lootDrop;
    //[SerializeField] private GameObject lootDrop;

    public GameObject SelectRandomLoot()
    {
        if (lootDrop.Count == 0)
        {
            Debug.LogWarning("Loot drop list is empty!");
            return null;
        }
        int randomIndex = Random.Range(0, lootDrop.Count);
        return lootDrop[randomIndex];
    }

    public void SpawnLootOnDeath(GameObject deadEnemy)
    {
        Instantiate(SelectRandomLoot(), deadEnemy.transform.position, deadEnemy.transform.rotation);
    }

    public void SpawnLootOnOpenChest(GameObject InteractableChest)
    {
        Instantiate(SelectRandomLoot(), InteractableChest.transform.position, InteractableChest.transform.rotation);
    }
}
