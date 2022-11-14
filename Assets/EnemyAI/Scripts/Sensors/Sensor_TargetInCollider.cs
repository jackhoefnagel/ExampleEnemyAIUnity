using UnityEngine;

public class Sensor_TargetInCollider : Sensor
{
    public Collider targetCollider;

    public bool targetIsInSight = false;
    
    public void OnTriggerStay(Collider other)
    {
        if (other == targetCollider)
        {
            targetIsInSight = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other == targetCollider)
        {
            targetIsInSight = false;
        }
    }

    public override bool IsSensorConditionTrue()
    {
        return targetIsInSight;
    }
}
