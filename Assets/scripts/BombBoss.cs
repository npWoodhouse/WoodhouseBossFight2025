using UnityEngine;

public class BombBoss : MonoBehaviour
{
    public BOSS_Health health;
    public GameObject blast;

    private float scaler = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        blast.transform.localScale += new Vector3(Time.deltaTime * scaler, Time.deltaTime * scaler, Time.deltaTime * scaler);
        health.currentHealth -= Time.deltaTime * scaler;
    }
}
