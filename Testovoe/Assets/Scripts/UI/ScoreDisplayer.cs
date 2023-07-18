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
        string text = $"������� �����: {value}";
        _currentScore.text = text.ToString();
    }

    private void OnBestWaveChanged(int value)
    {
        string text = $"������ �����: {value}";
        _bestScore.text = text.ToString();
    }

    private void Start()
    {
        _currentScore.text = $"������� �����: {_score.CurrentWave}".ToString();
        _bestScore.text = $"������ �����: {_score.BestWave}".ToString();
    }
}
