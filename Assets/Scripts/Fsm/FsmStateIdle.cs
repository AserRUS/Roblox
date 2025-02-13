using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmStateIdle : FsmState
{
    private InputControl inputControl;
    public FsmStateIdle(Fsm fsm, InputControl inputControl) : base(fsm)
    {
        this.inputControl = inputControl;
    }

    public override void Update()
    {
        
        fsm.SetState<FsmStateRun>();
        fsm.SetState<FsmStateJump>();
    }
}
