using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitHandler : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")) EndGame();
    }
    public void EndGame()
    {
        Debug.Log("Game end");
        SceneManager.LoadScene("WinScreen");
    }
}
