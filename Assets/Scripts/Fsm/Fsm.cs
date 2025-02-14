using System;
using System.Collections.Generic;

public class Fsm 
{
    private Dictionary<Type, FsmState> states = new Dictionary<Type, FsmState>();
    private FsmState currentState;

    public void AddState(FsmState state)
    {        
        states.Add(state.GetType(), state);
    }

    public void SetState<T>() where T : FsmState
    {
        var type = typeof(T);

        if (currentState != null)
        {
            if (currentState.GetType() == type) return;
        }
        
        
        if (states.TryGetValue(type, out var newState))
        {
            if (currentState != null)
            {
                currentState.Exit();                
            }
            currentState = newState;
            currentState.Enter();
        }

    }
    
    public void Update()
    {
        if (currentState != null)
        {
            currentState.Update();
        }
    }
}
