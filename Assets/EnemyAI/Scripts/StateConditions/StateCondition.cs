using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Listable and configurable reference for the Inspector,
//  indicating whether a sensor should check if it *should* or *shouldn't* detect something
[System.Serializable]
public class SensorCondition
{
    public Sensor sensor;
    public bool conditionShouldBeTrue;
}

// Inspector-configurable thing that checks for (sensor) conditions, and transitions from a current state to a target state
//  if the list of conditions are met
[System.Serializable]
public class StateTransition
{
    public StateController.States currentActiveState;
    public StateController.States targetState;
    public List<SensorCondition> sensorConditions;
    public float conditionDuration;

    public bool AllSensorConditionsTrue()
    {
        bool allSensorConditionsTrue = true;
        for (int i = 0; i < sensorConditions.Count; i++)
        {
            // This might be confusing, but note that first bool starts by assuming that all the sensors detect something,
            //  but we put that first bool on false when one of the conditions are not met.
            //  and note that in the SensorCondition class we can indicate if the condition *should* be true or false.
            //  So we're checking for a fail of that sensorcondition.
            if(sensorConditions[i].sensor.IsSensorConditionTrue() != sensorConditions[i].conditionShouldBeTrue)
            {
                allSensorConditionsTrue = false;
            }
        }
        return allSensorConditionsTrue;
    }
}

public class StateCondition : MonoBehaviour
{
    public StateController stateController;
    public StateTransition stateTransition;

    private float currentDurationTimer = 0f;

    public void Update()
    {        
        if(stateTransition.currentActiveState == stateController.currentState)
        {
            if (stateTransition.AllSensorConditionsTrue())
            {
                if(stateTransition.conditionDuration > 0f)
                {
                    currentDurationTimer += Time.deltaTime;
                    if(currentDurationTimer > stateTransition.conditionDuration)
                    {
                        stateController.SetCurrentState(stateTransition.targetState);
                        currentDurationTimer = 0f;
                    }
                }
                else
                {
                    stateController.SetCurrentState(stateTransition.targetState);
                    currentDurationTimer = 0f;
                }
                
            }
        }
    }

}
