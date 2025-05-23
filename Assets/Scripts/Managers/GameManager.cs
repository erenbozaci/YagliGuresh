using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameState CurrentState { get; private set; } = GameState.WaitingToStart;

    
    public int SuccessfulTravels { get; private set; } = 0;
    public int MaxSuccessesToWin = 10;
    public int CurrentLevel { get; private set; } = 0;

    public AttributeSelectionUI attributeUI;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        StartCoroutine(StartDungeon());
    }

    public IEnumerator StartDungeon()
    {
        yield return new WaitForSeconds(1f); // Let things initialize
        CurrentState = GameState.DungeonRunning;
        TimeManager.Instance.StartTimer();
    }

    public void OnDungeonCompleted()
    {
        if (CurrentState != GameState.DungeonRunning) return;

        CurrentState = GameState.DungeonCompleted;
        TimeManager.Instance.StopTimer();

        float bonus = TimeManager.Instance.GetRemainingPercentage();
        Debug.Log($"Dungeon completed. Time bonus: {bonus * 100}%");

        bool success = bonus >= 0.5f;

        if (success)
        {
            SuccessfulTravels++;
            CurrentLevel++;
        }
        else
        {
            SuccessfulTravels = Mathf.Max(0, SuccessfulTravels - 1);
            CurrentLevel = Mathf.Max(0, CurrentLevel - 1);
        }

        if (SuccessfulTravels >= MaxSuccessesToWin)
        {
            Debug.Log("🎉 You won the game!");
            // TODO: Show win screen
        }
        else
        {
            StartCoroutine(ProceedToAttributeSelection());
        }
    }

    private IEnumerator ProceedToAttributeSelection()
    {
        yield return new WaitForSeconds(2f);
        CurrentState = GameState.AttributeSelection;

        Debug.Log("Showing Attribute Selection UI...");
        attributeUI.ShowRandomAttributes();
        Time.timeScale = 0f; // Pause game
    }

    public void ProceedToNextLevel()
    {
        Time.timeScale = 1f;
        StartCoroutine(StartDungeon());
        // TODO: regenerate dungeon or load next scene
    }
}
