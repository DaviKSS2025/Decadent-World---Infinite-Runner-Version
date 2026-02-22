using System;
using UnityEngine;

// Handles high score persistence and notifies listeners when a new record is set.
public class SaveController : MonoBehaviour
{
    public static SaveController Instance;
    public Action<int> MaxScoreUpdated;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void SetMaxScore(int value)
    {
        if (value > SaveManager.Instance.Data.maxScore)
        {
            SaveManager.Instance.Data.maxScore = value;
            SaveManager.Instance.Save();

            MaxScoreUpdated?.Invoke(value);
        }
    }
}
