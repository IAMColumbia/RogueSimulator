using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Triggers an event after a specified amount of time passes.
/// </summary>
public class TimerTrigger : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnTimerFinished;

    [SerializeField]
    private float timeInSeconds;

    public float TimeInSeconds => timeInSeconds;
    public float TimeAccumulated => timeAccumulated;
    public bool IsTimerStarted => isTimerStarted;

    private bool isTimerStarted;
    private float timeAccumulated;


    void Update()
    {
        if (isTimerStarted)
        {        
            timeAccumulated += Time.deltaTime;
            if (timeAccumulated >= timeInSeconds)
            {
                isTimerStarted = false;
                OnTimerFinished?.Invoke();
                timeAccumulated = 0;
            }
        }
    }
    
    public void StartTimer()
    {
        isTimerStarted = true; 
    }
    
    /// <summary>
    /// Stops but doesn't reset the timer
    /// </summary>
    public void PauseTimer()
    {
        isTimerStarted = false;
    }
    
    /// <summary>
    /// Resets but doesn't stop the timer
    /// </summary>
    public void ResetTimer()
    {
        timeAccumulated = 0;
    }
    
    /// <summary>
    /// Stops and resets the timer
    /// </summary>
    public void StopTimer()
    {
        timeAccumulated = 0;
        isTimerStarted = false;
    }
    
    private void OnDisable()
    {
        StopTimer();
    }
}