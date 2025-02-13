using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private InputControl m_InputControl;
    [SerializeField] private Transform m_Target;
    [SerializeField] private float m_Sensitivity;
    [SerializeField] private Vector3 m_Offset;

    [Header("Rotation Limit")]
    [SerializeField] private float m_MaxLimitY;
    [SerializeField] private float m_MinLimitY;
    
    [Header("Distance")]
    [SerializeField] private float m_Distance;
    [SerializeField] private float m_MinDistance;
    [SerializeField] private float m_DistanceLerpRate;
    [SerializeField] private float m_DistanceOffsetFromCollisionHit;

    private float deltaRotationX;
    private float deltaRotationY;
    private Quaternion finalRotation;
    private Vector3 finalPosition;
    private RaycastHit hit;
    private float distanceToHit;
    private float currentDistance;
    private float targetDistance;

    private void LateUpdate()
    {
        RotationUpdate();        
        PositionUpdate();        
    }

    private void RotationUpdate()
    {
        if (m_InputControl == null) return;

        deltaRotationX += m_InputControl.DeltaRotation.x * m_Sensitivity;
        deltaRotationY -= m_InputControl.DeltaRotation.y * m_Sensitivity;

        deltaRotationY = ClampAngle(deltaRotationY, m_MinLimitY, m_MaxLimitY);
        finalRotation = Quaternion.Euler(deltaRotationY, deltaRotationX, 0);
        transform.rotation = finalRotation;
    }

    private void PositionUpdate()
    {
        finalPosition = m_Target.position - (finalRotation * Vector3.forward * m_Distance);
        finalPosition += m_Offset;

        targetDistance = m_Distance;

        if (Physics.Linecast(m_Target.position + new Vector3(0, m_Offset.y, 0), finalPosition, out hit))
        {
            distanceToHit = Vector3.Distance(m_Target.position + new Vector3(0, m_Offset.y, 0), hit.point);
            if (distanceToHit < m_Distance)
            {
                targetDistance  = distanceToHit - m_DistanceOffsetFromCollisionHit;
            }
        }
        currentDistance = Mathf.MoveTowards(currentDistance, targetDistance, Time.deltaTime * m_DistanceLerpRate);
        currentDistance = Mathf.Clamp(currentDistance, m_MinDistance, m_Distance);

        finalPosition = m_Target.position - (finalRotation * Vector3.forward * currentDistance);
        transform.position = finalPosition;
        transform.position += m_Offset;
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360;
        }
        if (angle > 360)
        {
            angle -= 360;
        }

        return Mathf.Clamp(angle, min, max);
    }

}
