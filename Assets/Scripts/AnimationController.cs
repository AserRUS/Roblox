using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator m_Animator;
    [SerializeField] private InputControl m_InputControl;
    [SerializeField] private MovementController m_MovementController;
    void Update()
    {
        m_Animator.SetBool("IsMove", m_InputControl.InputDirection != Vector2.zero);
        m_Animator.SetBool("IsGround", m_MovementController.IsGround);
    }
}
