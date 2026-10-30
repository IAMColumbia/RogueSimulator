using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Canvas myCanvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncreaseScore(int addition)
    {
        score = score + addition;
        if (scoreText == null)
        {
            scoreText = myCanvas.GetComponentInChildren<TextMeshProUGUI>();
        }
        scoreText.text = "Score: " + score;
    }
}
