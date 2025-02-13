using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FsmState 
{
    protected Fsm fsm;

    public FsmState(Fsm fsm)
    {
        this.fsm = fsm;
    }

    public virtual void Enter()
    {

    }
    public virtual void Exit()
    {

    }
    public virtual void Update()
    {

    }
}
