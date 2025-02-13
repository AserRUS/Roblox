using UnityEngine;

public class RotateTheObjectInTheDirectionOfMovement : MonoBehaviour
{
    [SerializeField] private float m_RotationSpeed;
    [SerializeField] private Transform m_TargetTransform;
    [SerializeField] private Transform m_Camera;
    [SerializeField] private InputControl m_InputControl;

    private Quaternion targetRotation;

    private void Update()
    {
        if (m_InputControl.InputDirection != Vector2.zero)
        {
            targetRotation = Quaternion.LookRotation(new Vector3(m_InputControl.InputDirection.normalized.x, 0, m_InputControl.InputDirection.normalized.y));
            m_TargetTransform.localRotation = Quaternion.RotateTowards(m_TargetTransform.localRotation, targetRotation, m_RotationSpeed * Time.deltaTime);
        }
    }
}
