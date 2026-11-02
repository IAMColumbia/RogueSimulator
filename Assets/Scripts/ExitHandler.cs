using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitHandler : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    private void Start()
    {
        if (scoreManager == null)
        {
            scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")) EndGame();
    }
    public void EndGame()
    {
        scoreManager.SaveScore();
        Debug.Log("Game end");
        SceneManager.LoadScene("WinScreen");
    }
}
