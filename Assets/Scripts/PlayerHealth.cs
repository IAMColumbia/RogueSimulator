using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int hp;
    private bool isDead = false;

    [SerializeField] private Animator animator;

    private PlayerMovement playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (hp <= 0 && !isDead && gameObject.CompareTag("Player"))
        {
            playerController.moveSpeed = 0f;
            playerController.enabled = false;

            animator.SetBool("IsDead", true);
            isDead = true;
        }
    }

    public void PlayerDeath()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void PlayerHit()
    {
        hp--;
    }
}