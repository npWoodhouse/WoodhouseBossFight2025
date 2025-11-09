using UnityEngine;

public class BOSS_Health : MonoBehaviour
{

    private int maxHealth = 100;
    public int currentHealth;

    public int phase = 1;

    void Awake()
    {
        currentHealth = maxHealth;
        phase = 1;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        phaseCheck();
    }

    void phaseCheck()
    {
        if (currentHealth <= 0)
        {
            phase += 1;
            Debug.Log("Boss Phase: " + phase);
            currentHealth = maxHealth;
        }
    }
}
