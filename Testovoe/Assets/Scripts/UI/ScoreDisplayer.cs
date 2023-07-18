using TMPro;
using UnityEngine;

public class ScoreDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentScore;
    [SerializeField] private TMP_Text _bestScore;
    [SerializeField] private Score _score;

    private void OnEnable()
    {
        _score.CurrentScoreChanged += OnCurrentScoreChanged;
    }

    private void OnDisable()
    {
        _score.BestWaveChanged += OnBestWaveChanged;
    }

    private void OnCurrentScoreChanged(int value)
    {
        string text = $"Текущая волна: {value}";
        _currentScore.text = text.ToString();
    }

    private void OnBestWaveChanged(int value)
    {
        string text = $"Лучшая волна: {value}";
        _bestScore.text = text.ToString();
    }

    private void Start()
    {
        _currentScore.text = $"Текущая волна: {_score.CurrentWave}".ToString();
        _bestScore.text = $"Лучшая волна: {_score.BestWave}".ToString();
    }
}
