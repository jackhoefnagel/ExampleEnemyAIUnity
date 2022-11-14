using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBehaviour : MonoBehaviour
{
    public bool loopActions = true;
    public List<Action> actions;

    private Coroutine cor_ProcessActions;

    public int i;

    private void OnEnable()
    {
        if (actions.Count == 0)
        {
            Action[] childActions = transform.GetComponentsInChildren<Action>(true);
            for (int k = 0; k < childActions.Length; k++)
            {
                actions.Add(childActions[k]);
            }
        }

        if (cor_ProcessActions == null)
        {            
            cor_ProcessActions = StartCoroutine(ProcessActions());
        }
    }

    private void OnDisable()
    {
        if(cor_ProcessActions != null)
        {
            StopCoroutine(cor_ProcessActions);
            cor_ProcessActions = null;            
        }
    }

    private IEnumerator ProcessActions()
    {
        i = 0;

        while(i < actions.Count)
        {
            actions[i].gameObject.SetActive(true);
            yield return new WaitUntil(actions[i].IsActionFinished);
            actions[i].gameObject.SetActive(false);

            i++;

            if (i == actions.Count && loopActions == true)
            {
                i = 0;
            }           
        }

        for (int j = 0; j < actions.Count; j++)
        {
            actions[j].gameObject.SetActive(false);
        }        
    }
}
