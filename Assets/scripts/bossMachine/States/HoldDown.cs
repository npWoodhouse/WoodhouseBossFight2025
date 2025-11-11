using UnityEngine;

public class HoldDown : BossState
{
    public override void Act()
    {return;}

    public override void enter()
    {
        bsc.transform.position = new Vector3(0,10,0);
    }

    public override void state_Update()
    {
        if (bsc.transform.position.y > 0)
        {
            bsc.transform.position -= new Vector3(0,bsc.speed * Time.deltaTime,0);
        }
        else
        {
            bsc.change_state(bsc.hold);
        }
    }
}
