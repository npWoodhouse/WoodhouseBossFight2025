using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public GameObject playerpref, boss1, Bomb, Squarefloor, evilsquare, boss, smallBomb, currentBomb;
    private GameObject player, bosspref, arena1, arena2;
    public GameObject[] platforming;
    private Vector3 playerSpawn, bossSpawn;
    public TMP_Text livecounter;
    public int phase = 0;
    public int Lives = 10;
    private bool PlayerSpawned, canBomb, bombStarted;
    private float cooldown;

    void Start()
    {
        PlayerSpawned = false;
        Lives = 10;
        phase = 1;
        bosspref = boss1;
        playerSpawn = new Vector3(0, 0, -5);
        bossSpawn = new Vector3(-14, 1, 14);
        SpawnPlayer();
        arena1 = Instantiate(Squarefloor, new Vector3(0, -1, 0), Quaternion.identity);
        SpawnBoss();
        canBomb = false;
        bombStarted = false;
    }

    void Update()
    {
        SpawnBombs();
    }

    private void SpawnPlayer()
    {
        player = Instantiate(playerpref, playerSpawn, Quaternion.identity);
        player.GetComponent<HeadRotation>().gm = this;

        livecounter.text = "Lives: " + Lives.ToString();
        PlayerSpawned = true;
    }
    
    private void SpawnBoss()
    {
        boss = Instantiate(bosspref, bossSpawn, Quaternion.identity);

        boss.GetComponent<BOSS_Health>().gameManager = this;
        boss.GetComponent<BOSS_Health>().phase = phase;
    }

    private void SpawnBombs()
    {
        if (bombStarted)
        {
            if (canBomb)
            {
                if (cooldown > 0)
                {
                    cooldown -= Time.deltaTime;
                }
                else
                {
                    currentBomb = Instantiate(smallBomb, new Vector3(player.transform.position.x, player.transform.position.y + 2f, player.transform.position.z), Quaternion.identity);
                    canBomb = false;
                }
            }else
            {
                cooldown = Random.Range(3, 8);
                canBomb = true;
            }
        }
        
    }

    public void killPlayer()
    {
        Destroy(currentBomb);
        Destroy(player);
        Destroy(boss);

        if (phase > 1 && PlayerSpawned)
        {
            Lives -= 1;
            Debug.Log(Lives);
        }

        PlayerSpawned = false;

        if (Lives > 0)
        {
            SpawnPlayer();
            SpawnBoss();
        }
        else
        {
            Debug.Log("GAME OVER");
            SceneManager.LoadScene("GameOver");
        }
    }

    public void nextPhase()
    {
        Destroy(boss);

        if (phase == 2)
        {
            playerSpawn = new Vector3(0, 0, -5);
            bossSpawn = new Vector3(0, 1, 14);
            arena2 = Instantiate(platforming[Random.Range(0, platforming.Length - 1)], new Vector3(0, -1, 0), Quaternion.identity);
            Instantiate(evilsquare, new Vector3(0, -1, -137), Quaternion.identity);
            bosspref = Bomb;
            SpawnBoss();
        }
        if (phase == 3)
        {
            bombStarted = true;
            Destroy(arena1);
            Destroy(arena2);
            playerSpawn = new Vector3(6, 0, -143);
            bossSpawn = new Vector3(-14, 1, 14);
            bossSpawn = new Vector3(-14, 1, -123);
            bosspref = boss1;
            SpawnBoss();
        }
        if (phase > 3)
        {
            bombStarted = false;
            StartCoroutine(WIN());
        }
    }
    
    IEnumerator WIN()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("GameWin");
    }
}
