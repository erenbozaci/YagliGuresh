using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }

    public float maxTime = 100f;
    private float currentTime;
    private bool running;
    private float remainingTime;


    public Action<float> OnTimerUpdated;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void StartTimer()
    {
        currentTime = maxTime;
        running = true;
    }
    
    public float GetTimeRemaining()
    {
        return Mathf.Max(0, remainingTime);
    }

    
    public void StopTimer()
    {
        running = false;
    }

    private void Update()
    {
        if (!running) return;

        currentTime -= Time.deltaTime;

        OnTimerUpdated?.Invoke(currentTime);

        if (currentTime <= 0)
        {
            currentTime = 0;
            running = false;
            GameManager.Instance.OnDungeonCompleted(); // auto-failover
        }
    }

    public float GetRemainingPercentage()
    {
        return Mathf.Clamp01(currentTime / maxTime);
    }
}