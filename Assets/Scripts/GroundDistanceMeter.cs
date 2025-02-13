using UnityEngine;

public class GroundDistanceMeter : MonoBehaviour
{
    public float DistanceToGround => distanceToGround;
    private float distanceToGround;
    private RaycastHit hit;
    private void Update()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out hit, 1000))
        {
            distanceToGround = hit.distance;
        }
    }
}
