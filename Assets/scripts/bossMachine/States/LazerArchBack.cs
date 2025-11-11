using UnityEngine;

public class LazerArchBack : BossState
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
        dalerp += Time.deltaTime * bsc.speed * 10f;
        if (dalerp <= 90f)
        {
            bsc.transform.eulerAngles -= new Vector3(0, Time.deltaTime * bsc.speed * 10f, 0);
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
            bsc.change_state(bsc.lazerfan);
        }
        else if (roll > 50 && roll <= 80)
        {
            bsc.change_state(bsc.lazerSweepBack);
        }
    }
}