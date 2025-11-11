using UnityEngine;

public class HoldUP : BossState
{
    public override void Act()
    {return;}

    public override void state_Update()
    {
        if (bsc.transform.position.y < 10)
        {
            bsc.transform.position += new Vector3(0,bsc.speed * Time.deltaTime,0);
        }
        else
        {
            bsc.change_state(bsc.LazerDown);  
        }
    }
}