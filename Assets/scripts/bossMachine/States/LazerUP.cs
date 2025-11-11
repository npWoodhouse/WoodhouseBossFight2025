using UnityEngine;

public class LazerUP : BossState
{

    public override void enter()
    {
        bsc.lazer1.SetActive(false);
    }

    public override void Act()
    {return;}

    public override void state_Update()
    {
        if (bsc.transform.position.y < 10)
        {
            bsc.transform.position += new Vector3(0, bsc.speed * Time.deltaTime, 0);
        }
        else
        {
            //20% chance to hold 80% chance to lazer again
            float roll = Random.Range(0f, 100f);
            if (roll >= 20)
            {
                bsc.change_state(bsc.LazerDown);
            }
            else if (roll < 20)
            {
                bsc.change_state(bsc.HoldDown);
            }
        }
    }

    public override void exit()
    {
        bsc.transform.eulerAngles += new Vector3(0, 0, 0);
    }
}
