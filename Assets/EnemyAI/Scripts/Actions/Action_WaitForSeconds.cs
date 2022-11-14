using System.Collections;
using UnityEngine;

public class Action_WaitForSeconds : Action
{
    public float secondsToWait;
    public bool isWaitTimeOver;
    public float timer;
    private Coroutine cor_Timer;

    private void OnEnable()
    {
        isWaitTimeOver = false;
        timer = 0f;
        cor_Timer = StartCoroutine(DoWaitForSeconds());
    }

    private void OnDisable()
    {
        isWaitTimeOver = false;
        timer = 0f;

        if (cor_Timer != null)
        {
            StopCoroutine(cor_Timer);
        }
    }

    private IEnumerator DoWaitForSeconds()
    {
        
        while (timer < secondsToWait)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        isWaitTimeOver = true;
    }

    public override bool IsActionFinished()
    {
        return isWaitTimeOver;
    }
}
