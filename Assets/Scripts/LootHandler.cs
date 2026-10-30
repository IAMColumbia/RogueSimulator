using UnityEngine;

public class LootHandler : MonoBehaviour
{
    private ScoreManager scoreManager;
    [SerializeField] private int value = 1;
    //Animation anim blah blah
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    public void LootIsGathered()
    {
        //add animation logic here
        scoreManager.IncreaseScore(value);
    }
}
