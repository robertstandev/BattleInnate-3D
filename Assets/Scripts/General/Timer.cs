using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timer : MonoBehaviour
{
    private List<IEnumerator> timersList = new List<IEnumerator>();

    public void startTimer(int index) { StartCoroutine(timersList[index]); }
    public void stopTimer(int index) { StopCoroutine(timersList[index]); }
    
    public int createTimerInstanceAndGetIndex(bool repeatCoroutine,float waitTime, Action method)
    {
        timersList.Add(timer(repeatCoroutine, waitTime, method));
        return timersList.Count - 1;
    }

    private IEnumerator timer(bool repeatCoroutine, float waitTime, Action method){
        WaitForSeconds wait = new WaitForSeconds(waitTime);
        
        while(true){
            yield return wait;
            method?.Invoke();
            if(!repeatCoroutine){
                yield break;
            }
        }
    }
}
