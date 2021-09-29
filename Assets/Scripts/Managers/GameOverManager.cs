using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Text warningText;

    public float restartDelay = 5f;


    Animator anim;
    float restartTimer;
    private bool isAnimPlayed;


    void Awake()
    {
        anim = GetComponent<Animator>();
        isAnimPlayed = false;
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");
            anim.SetBool("IsAnimPlayed", !isAnimPlayed);
            isAnimPlayed = true;

            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void ShowWarning(float enemyDistance)
    {
        warningText.text = string.Format("! {0} m", Mathf.RoundToInt(enemyDistance));

        anim.SetTrigger("Warning");
    }
}