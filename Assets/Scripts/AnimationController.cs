using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator m_Animator;
   
    public void SetMove(bool value)
    {
        m_Animator.SetBool("IsMove", value);
    }

    public void SetGround(bool value)
    {
        m_Animator.SetBool("IsGround", value);
    }
}
