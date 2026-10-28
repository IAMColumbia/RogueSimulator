using Unity.VisualScripting;
using UnityEngine;

public class SpikeHandler : MonoBehaviour
{
    TriggerVolume volume;
    PlayerHealth health;
    bool isSpikeActive = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        volume = GetComponent<TriggerVolume>();
        health = FindFirstObjectByType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isSpikeActive == true) isSpikeActive = false;
    }

    public void SpikeTriggered()
    {
        isSpikeActive = true;


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

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Something has entered the SpikeHandler's Collider");
        if (other.CompareTag("Enemy"))
        {
            if(isSpikeActive == true)
            {
                GameObject enemy = other.attachedRigidbody != null
                ? other.attachedRigidbody.gameObject
                : other.gameObject;
            Destroy(enemy);
            }

        }
    }
}
