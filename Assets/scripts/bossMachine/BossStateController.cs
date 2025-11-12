using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class BossStateController : MonoBehaviour
{
    public GameObject lazer1;
    public BOSS_Health hp;
    public BossState starting_state;
    public BossState current_state;
    public BossState UpNext;

    public bool actioncomplete = true;

    public float speed = 2.0f;
    public float startROT;
    
    [Header("States")]
    public BossState LazerUP;
    public BossState LazerDown;
    public BossState HoldUP;
    public BossState HoldDown;
    public BossState hold;
    public BossState lazerfan;
    public BossState lazerfanBack;
    public BossState lazerSweep;
    public BossState lazerSweepBack;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        change_state(starting_state);
        hp = GetComponent<BOSS_Health>();
    }

    void Update()
    {
        if (current_state != null)
        {
            current_state.state_Update();
        }
        speed = hp.phase * 2f;
    }

    public virtual void change_state(BossState newstate)
    {
        if(current_state != null)
        {
            current_state.exit();
        }
        current_state = newstate;
        current_state.enter();
    }

    public virtual void GoNext()
    {
        current_state.next_State();
    }

    public void RandomCorner()
    {
        transform.position = new Vector3(-14,10,14);
        transform.eulerAngles += new Vector3(0, 0, 0);
    }
}