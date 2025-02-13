using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmStateRun : FsmState
{
    public FsmStateRun(Fsm fsm) : base(fsm)
    {
    }

    public override void Update()
    {
        fsm.SetState<FsmStateRun>();
        fsm.SetState<FsmStateJump>();
    }
}
