using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider other)
    {
        Debug.Log("Game end");
        if (other.CompareTag("Player"))
            SceneManager.LoadScene("WinScene");
    }
}
