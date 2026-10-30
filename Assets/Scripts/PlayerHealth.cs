using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int hp;
    bool isDead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0 && isDead == false)
        {
            Debug.Log("Do Game Over Stuff Here");
            isDead = true;
        }
    }

    public void PlayerHit()
    {
        //Will need to call animation stuff here
        hp--;
    }
}
