using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

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
        scoreText.text = "Score: " + score;
    }
}
