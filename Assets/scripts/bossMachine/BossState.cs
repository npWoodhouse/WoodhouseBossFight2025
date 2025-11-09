using UnityEngine;
using System.Collections;

public abstract class BossState : MonoBehaviour
{
    protected BossStateController bsc;

    public BossState nextAction;
    public Vector3 TargetPos;
    
    protected virtual void Awake()
    {
        bsc = GetComponent<BossStateController>();
    }

    public virtual void enter()
    {}

    public abstract void Act();

    public virtual void state_Update()
    {}

    public virtual void next_State()
    {}

    public virtual void exit()
    {}
}