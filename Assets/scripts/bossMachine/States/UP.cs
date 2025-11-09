using UnityEngine;

public class UP : BossState
{
    public override void Act()
    {return;}

    public override void state_Update()
    {
        if (bsc.Body.transform.position.y < 10)
        {
            bsc.Body.transform.position += new Vector3(0,bsc.speed * Time.deltaTime,0);
        }
        else
        {
            bsc.RandomAction();
        }
    }
}
