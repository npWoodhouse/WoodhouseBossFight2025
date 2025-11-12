using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerpref, bosspref, boss1, Bomb, player, boss;
    public Vector3 playerSpawn, bossSpawn;
    public int phase = 0;

    void Start()
    {
        phase = 1;
        bosspref = boss1;
        playerSpawn = new Vector3(0, 0, -5);
        bossSpawn = new Vector3(-14, 1, 14);
        player = Instantiate(playerpref, playerSpawn, Quaternion.identity);
        StartPhase();
    }

    private void StartPhase()
    {
        boss = Instantiate(bosspref, bossSpawn, Quaternion.identity);

        boss.GetComponent<BOSS_Health>().gameManager = this;
        boss.GetComponent<BOSS_Health>().phase = phase;

    }

    public void nextPhase()
    {
        Destroy(boss);
        
        if (phase == 2)
        {
            playerSpawn = new Vector3(0, 0, -5);
            bossSpawn = new Vector3(0, 1, 0);
            bosspref = Bomb;
            StartPhase();
        }
        if(phase == 3)
        {
            playerSpawn = new Vector3(0, 0, -5);
            bossSpawn = new Vector3(-14, 1, 14);
            bosspref = boss1;
            StartPhase();
        }
    }
}
