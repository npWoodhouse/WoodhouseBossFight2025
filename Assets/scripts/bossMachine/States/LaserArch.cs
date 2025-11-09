using UnityEngine;
using System.Collections;

public class LaserArch : BossState
{
    public override void Act()
    {return;}

    public override void enter()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(Random.Range(1.0f, 5.0f));
        bsc.change_state(bsc.UP);
    }
}