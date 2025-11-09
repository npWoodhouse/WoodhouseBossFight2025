using UnityEngine;

public class DOWN : BossState
{
    public override void Act()
    {return;}

    public override void enter()
    {
        bsc.RandomCorner();
        bsc.Body.transform.position = TargetPos;
    }

    public override void state_Update()
    {
        if (bsc.Body.transform.position.y > 1)
        {
            bsc.Body.transform.position -= new Vector3(0,bsc.speed * Time.deltaTime,0);
        }
        else
        {
            bsc.change_state(nextAction);
        }
    }
}
