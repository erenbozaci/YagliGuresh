using TMPro;
using UnityEngine;

public class DungeonTimerUI : MonoBehaviour
{
    public TMP_Text timerText;

    private void OnEnable()
    {
        if (TimeManager.Instance != null)
            TimeManager.Instance.OnTimerUpdated += UpdateTimer;
        else
            Debug.LogError("TimeManager instance is null. Make sure it is initialized before DungeonTimerUI.");
    }

    private void OnDisable()
    {
        if (TimeManager.Instance != null)
            TimeManager.Instance.OnTimerUpdated -= UpdateTimer;
    }

    private void UpdateTimer(float time)
    {
        timerText.text = time.ToString("F1");
    }
}