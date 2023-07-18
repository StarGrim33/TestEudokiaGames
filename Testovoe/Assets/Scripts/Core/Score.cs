using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    public event UnityAction<int> CurrentScoreChanged;

    public event UnityAction<int> BestWaveChanged;

    private void Awake()
    {
        PlayerData.BestWave = PlayerPrefs.GetInt(Constants.BestWave, 0);
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
        PlayerData.CurrentWave++;

        if (PlayerData.CurrentWave > PlayerData.BestWave)
        {
            PlayerData.BestWave = PlayerData.CurrentWave;
            PlayerPrefs.SetInt(Constants.BestWave, PlayerData.BestWave);
            BestWaveChanged?.Invoke(PlayerData.BestWave);
        }

        CurrentScoreChanged?.Invoke(PlayerData.CurrentWave);
    }
}
