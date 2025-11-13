using UnityEngine;

public class SmallBomb : MonoBehaviour
{
    public float health;
    public GameObject blast, me;

    private float scaler = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        blast.transform.localScale += new Vector3(Time.deltaTime * scaler, Time.deltaTime * scaler, Time.deltaTime * scaler);
        health -= Time.deltaTime * scaler / 2f;

        if (health < 0f)
        {
            Destroy(me);
        }
    }
}