using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    public event UnityAction<int> CurrentScoreChanged;

    public event UnityAction<int> BestWaveChanged;

    public int CurrentWave => _currentWave;

    public int BestWave => _bestWave;

    private int _currentWave = 0;
    private int _bestWave = 0;

    private void Awake()
    {
        _bestWave = PlayerPrefs.GetInt(Constants.BestWave, 0);
    }

    private void OnEnable()
    {
        _spawner.AllEnemySpawned += OnAllEnemySpawned;
    }
    private void OnDisable()
    {
        _spawner.AllEnemySpawned -= OnAllEnemySpawned;
    }

    private void OnAllEnemySpawned()
    {
        _currentWave++;

        if (_currentWave > _bestWave)
        {
            _bestWave = _currentWave;
            PlayerPrefs.SetInt(Constants.BestWave, _bestWave);
            BestWaveChanged?.Invoke(_bestWave);
        }

        CurrentScoreChanged?.Invoke(_currentWave);
    }
}
