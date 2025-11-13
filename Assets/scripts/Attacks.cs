using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Attacks : MonoBehaviour
{
    private PlayerInput playerInput;

    public GameObject SlashBox;

    [SerializeField] private GameObject bullet, bulletlaunchpos;
    private bool isShooting = false;
    private GameObject gamecontroller;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gamecontroller = GameObject.Find("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInput.actions["Attack"].triggered)
        {
            slash();
        }

        if (!isShooting && playerInput.actions["shoot"].triggered){shootgun();}
    }

    void slash()
    {
        Instantiate(SlashBox, bulletlaunchpos.transform.position, Quaternion.identity);

    }

    void shootgun()
    {
        isShooting = true;

        bullet = gamecontroller.GetComponent<BulletPool>().GetBulletFromPool();
        
        bullet.transform.position = bulletlaunchpos.transform.position;
        bullet.transform.rotation = bulletlaunchpos.transform.rotation;

        bullet.GetComponent<Rigidbody>().AddForce(bulletlaunchpos.transform.up * 500, ForceMode.Impulse);
        StartCoroutine(ShootingCooldown());
    }

    IEnumerator ShootingCooldown()
    {
        yield return new WaitForSeconds(0.1f);
        isShooting = false;
    }
}
