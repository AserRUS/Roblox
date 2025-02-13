using UnityEngine;

public class InputControl : MonoBehaviour
{
    public Vector2 DeltaRotation => deltaRotation;
    public Vector2 InputDirection => inputDirection;
    public bool IsJump => isJump;

    private Vector2 deltaRotation;
    private Vector2 inputDirection;
    private bool isJump;
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            inputDirection.x = 1;
        }
        else if (Input.GetKey(KeyCode.A))        
        {
            inputDirection.x = -1;
        }
        else
        {
            inputDirection.x = 0;
        }

        if (Input.GetKey(KeyCode.W))
        {
            inputDirection.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            inputDirection.y = -1;
        }
        else
        {
            inputDirection.y = 0;
        }

        deltaRotation.x = Input.GetAxis("Mouse X");
        deltaRotation.y = Input.GetAxis("Mouse Y");

        isJump = Input.GetButtonDown("Jump");
        
    }
}
