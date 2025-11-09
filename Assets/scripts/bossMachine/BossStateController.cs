using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class BossStateController : MonoBehaviour
{
    public GameObject Body, lazer1;
    public BossState starting_state;
    public BossState current_state;
    public BossState UpNext;

    public bool actioncomplete = true;

    public float speed = 2.0f;
    
    [Header("States")]
    public BossState UP;
    public BossState Down;
    public BossState hold;
    public BossState laserfan;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        change_state(starting_state);
    }

    void Update()
    {
        if (current_state != null)
        {
            current_state.state_Update();
        } 
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
        float roll = Random.Range(0f, 100f);
        if (roll <= 25)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }else if (roll > 25 && roll <= 50)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }else if (roll > 50 && roll <= 75)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }else if (roll > 75)
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
    }

    public void RandomAction()
    {
        float roll = Random.Range(0f, 100f);
        if ( roll >= 20)
        {
            RandomCorner();
            Down.TargetPos = new Vector3(14,10,14);
            Down.nextAction = laserfan;
            change_state(Down);
        }else if (roll < 20)
        {
            Down.TargetPos = new Vector3(0,10,0);
            Down.nextAction = hold;
            change_state(Down);
        }  
    }
}