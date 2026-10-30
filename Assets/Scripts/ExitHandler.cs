using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitHandler : MonoBehaviour
{
    public void EndGame()
    {
        Debug.Log("Game end");
        SceneManager.LoadScene("WinScene");
    }
}
