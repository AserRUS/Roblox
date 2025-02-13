using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private InputControl m_InputControl;
    [SerializeField] private CharacterController m_CharacterController;
    [SerializeField] private float m_MoveSpeed;
    [SerializeField] private float m_JumpSpeed;

    private Vector3 movementDirection;
    private Vector2 inputDirection;

    

    void Update()
    {
        DirectionUpdate();
        Jump();
        ApplyGravity();
        Move();
    }   

    private void DirectionUpdate()
    {
        if (m_InputControl == null) return;

        inputDirection = m_InputControl.InputDirection.normalized;

        movementDirection.x = inputDirection.x * m_MoveSpeed;
        movementDirection.z = inputDirection.y * m_MoveSpeed;
    }
    private void Jump()
    {
        if (m_InputControl == null) return;

        if (m_CharacterController.isGrounded)
        {
            if (m_InputControl.IsJump)
            {
                movementDirection.y = m_JumpSpeed;
            }
        }
    }
    private void ApplyGravity()
    {
        movementDirection += Physics.gravity * Time.deltaTime;
    }
    private void Move()
    {
        movementDirection = transform.TransformDirection(movementDirection);
        m_CharacterController.Move(movementDirection * Time.deltaTime);
    }
    
    
}
