using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float m_MoveSpeed;
    [SerializeField] private float m_JumpSpeed;
    [SerializeField] private MovementController m_MovementController;
    [SerializeField] private InputControl m_InputControl;

    private Fsm fsm;

    private void Start()
    {
        fsm = new Fsm();

        fsm.AddState(new FsmStateIdle(fsm, m_InputControl));
        fsm.AddState(new FsmStateRun(fsm));
        fsm.AddState(new FsmStateJump(fsm));

        fsm.SetState<FsmStateIdle>();
    }

    private void Update()
    {
        fsm.Update();
    }
}
