using UnityEngine;

public class RotateTheObjectInTheDirectionOfTheCamera : MonoBehaviour
{
    [SerializeField] private Transform m_TargetTransform;
    [SerializeField] private Transform m_Camera;
    [SerializeField] private InputControl m_InputControl;


    private void Update()
    {
        if (m_InputControl.InputDirection != Vector2.zero)
        {
            m_TargetTransform.rotation = Quaternion.Euler(m_TargetTransform.eulerAngles.x, m_Camera.eulerAngles.y, m_TargetTransform.eulerAngles.z);
        }
    }
}
