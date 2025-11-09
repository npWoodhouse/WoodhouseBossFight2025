using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject gamecontroller;
    private Rigidbody rb;
    private float startTime;
    public int shootDamage = 2;

    private void OnEnable()
    {
        gamecontroller = GameObject.Find("GameController");
        rb = GetComponent<Rigidbody>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime > 2f)
        {
            ReturnToPool();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boss"))
        {
            BOSS_Health BOSS = other.GetComponent<BOSS_Health>();
            BOSS.currentHealth -= shootDamage;
            Debug.Log("Boss Health: " + BOSS.currentHealth);
            ReturnToPool();
        }
    }

    private void ReturnToPool()
    {
        rb.linearVelocity = Vector3.zero;
        gamecontroller.GetComponent<BulletPool>().ReturnBulletToPool(gameObject);
    }
}
