using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorsSetup : MonoBehaviour
{
    public StateController stateController;
    public bool shouldSensorsHavePlayerAsTarget = true;
    public List<Sensor> sensorsToSetup;

    void Start()
    {
        if (shouldSensorsHavePlayerAsTarget)
        {
            for (int i = 0; i < sensorsToSetup.Count; i++)
            {

                switch (sensorsToSetup[i])
                {
                    case Sensor_TargetInCollider:
                        Sensor_TargetInCollider tic = (Sensor_TargetInCollider)sensorsToSetup[i];
                        tic.targetCollider = stateController.playerTransform.GetComponent<Collider>();
                        break;
                    case Sensor_LineOfSight:
                        Sensor_LineOfSight los = (Sensor_LineOfSight)sensorsToSetup[i];
                        los.targetCollider = stateController.playerTransform.GetComponent<Collider>();
                        break;
                }
            }
        }
    }
}
