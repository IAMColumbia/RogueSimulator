using Unity.VisualScripting;
using UnityEngine;

public class SpikeHandler : MonoBehaviour
{
    TriggerVolume volume;
    PlayerHealth health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        volume = GetComponent<TriggerVolume>();
        health = FindFirstObjectByType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpikeTriggered()
    {
        if(volume.isPlayerThere == true)
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
}
