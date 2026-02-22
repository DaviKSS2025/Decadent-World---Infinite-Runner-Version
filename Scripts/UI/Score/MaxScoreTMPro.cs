using TMPro;
using UnityEngine;

[RequireComponent (typeof(TextMeshProUGUI))]
public class MaxScoreTMPro : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        SaveController.Instance.MaxScoreUpdated += UpdateText;

        UpdateText(SaveManager.Instance.Data.maxScore);
    }

    private void OnDisable()
    {
        SaveController.Instance.MaxScoreUpdated -= UpdateText;
    }

    private void UpdateText(int value)
    {
        _text.text = $"MaxScore: {value}";
    }
}
