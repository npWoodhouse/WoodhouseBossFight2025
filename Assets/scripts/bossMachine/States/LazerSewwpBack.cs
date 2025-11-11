using UnityEngine;

public class LazerSewwpBack : BossState
{
    private float dalerp;
    public override void Act()
    {return;}

    public override void enter()
    {
        bsc.lazer1.SetActive(true);
        dalerp = 0f;         
    }

    public override void state_Update()
    {
        dalerp += Time.deltaTime * bsc.speed * 3f;
        if (dalerp <= 28f)
        {
            bsc.transform.Translate(Vector3.left * bsc.speed * Time.deltaTime * 3f);
        }
        else
        {
            RandomState();
        }
    }

    public override void exit()
    {
        bsc.lazer1.SetActive(false);
    }

    public void RandomState()
    {
        float roll = Random.Range(0f, 100f);
        if (roll <= 50)
        {
            bsc.change_state(bsc.lazerfanBack);
        }
        else if (roll > 50 && roll <= 80)
        {
            bsc.change_state(bsc.lazerSweep);
        }
    }
}