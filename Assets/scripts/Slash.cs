using UnityEngine;

public class Slash : MonoBehaviour
{
    public int slashDamage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boss"))
        {
            BOSS_Health BOSS = other.GetComponent<BOSS_Health>();
            BOSS.currentHealth -= slashDamage;
            Debug.Log("Boss Health: " + BOSS.currentHealth);
        }
    }
}
