using UnityEngine;
using System.Collections;

public class Hold : BossState
{
    public override void Act()
    {return;}
    
    public override void enter()
    {
        bsc.lazer1.SetActive(false);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(Random.Range(1.0f, 5.0f));
        bsc.change_state(bsc.UP);
    }
}
