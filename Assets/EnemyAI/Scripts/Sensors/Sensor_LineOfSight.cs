using UnityEngine;

public class Sensor_LineOfSight : Sensor
{
    public Collider targetCollider;

    public bool targetIsInSight = false;
    public Transform rayTransform;

    public void Update()
    {
        Ray ray = new Ray(rayTransform.position, rayTransform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10))
        {
            if(hit.collider == targetCollider)
            {
                targetIsInSight = true;
            }
            else
            {
                targetIsInSight = false;
            }
        }
        else
        {
            targetIsInSight = false;
        }
    }

    public override bool IsSensorConditionTrue()
    {
        return targetIsInSight;
    }
}
