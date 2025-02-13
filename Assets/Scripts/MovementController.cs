using UnityEngine;

public class MovementController : MonoBehaviour
{
    public bool IsGround => isGround;

    [SerializeField] private CharacterController m_CharacterController;    

    private bool isGround;
    private Vector3 movementDirection;

    public void GroundCheck()
    {
        isGround = m_CharacterController.isGrounded;
        if (isGround)
        {
            movementDirection.y = -0.1f;
        }
    }

    public void DirectionUpdate(Vector2 inputDirection, float moveSpeed)
    {

        inputDirection = inputDirection.normalized;

        movementDirection.x = inputDirection.x * moveSpeed;
        movementDirection.z = inputDirection.y * moveSpeed;
    }
    public void Jump(float jumpSpeed)    
    {                       
        movementDirection.y = jumpSpeed;    
    }
    public void ApplyGravity()
    {
        movementDirection += Physics.gravity * Time.deltaTime;        
    }
    public void Move()
    {     
        movementDirection = transform.TransformDirection(movementDirection);
        m_CharacterController.Move(movementDirection * Time.deltaTime);
    }
    
    
}
