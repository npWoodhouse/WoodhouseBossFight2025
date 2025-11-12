using UnityEngine;

public class BOSS_Health : MonoBehaviour
{

    private int maxHealth = 100;
    public GameManager gameManager;
    public float currentHealth;

    public int phase = 1;

    void Awake()
    {
        currentHealth = maxHealth;

    }

    void Update()
    {
        phaseCheck();
    }

    void phaseCheck()
    {
        if (currentHealth <= 0)
        {
            phase += 1;
            gameManager.phase = phase;
            gameManager.nextPhase();
        }
    }
}
