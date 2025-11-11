using UnityEngine;

public class LazerDOWN : BossState
{
    public override void Act()
    {return;}

    public override void enter()
    {
        bsc.RandomCorner();
        //bsc.Body.transform.position = new Vector3(14,10,14);
    }

    public override void state_Update()
    {
        if (bsc.transform.position.y > 0.5)
        {
            bsc.transform.position -= new Vector3(0, bsc.speed * Time.deltaTime, 0);
        }
        else
        {
            //random lazer attack
            Randomlazer();
        }
    }
    
    public void Randomlazer()
    {
        float roll = Random.Range(0f, 100f);
        if (roll <= 50)
        {
            bsc.change_state(bsc.lazerSweep);
        }
        else if (roll > 50 && roll <= 100)
        {
            bsc.change_state(bsc.lazerSweep);
        }
    }
}
