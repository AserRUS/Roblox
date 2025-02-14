using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float m_MoveSpeed;
    [SerializeField] private float m_JumpSpeed;
    [SerializeField] private MovementController m_MovementController;
    [SerializeField] private InputControl m_InputControl;
    [SerializeField] private AnimationController m_AnimationController;

    private Fsm fsm;

    private void Start()
    {
        fsm = new Fsm();

        fsm.AddState(new FsmStateIdle(fsm, m_AnimationController, m_InputControl, m_MovementController, m_JumpSpeed));
        fsm.AddState(new FsmStateRun(fsm, m_AnimationController, m_InputControl, m_MovementController, m_MoveSpeed, m_JumpSpeed));
        fsm.AddState(new FsmStateFlight(fsm, m_AnimationController, m_InputControl, m_MovementController, m_MoveSpeed));

        fsm.SetState<FsmStateIdle>();
    }

    private void Update()
    {
        fsm.Update();
    }
}
