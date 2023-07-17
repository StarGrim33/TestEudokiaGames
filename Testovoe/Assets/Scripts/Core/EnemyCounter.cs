using UnityEngine;
using UnityEngine.Events;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] private GameObject _enemyContainer;
    [SerializeField] private GameObject _loseScreen;

    [SerializeField] private int _enemyAmount;

    public event UnityAction<int, int> EnemyCountChanged;

    public int MaxEnemyCount => _maxEnemyCount;
    public int EnemyAmount => _enemyAmount;

    private int _maxEnemyCount = 10;

    private void Update()
    {
        CountEnemies();

        if(_enemyAmount >= _maxEnemyCount)
        {
            ShowLoseScreen();
        }
    }

    private void CountEnemies()
    {
        _enemyAmount = 0;

        for (int i  = 0; i < _enemyContainer.transform.childCount; i++)
        {
            if(_enemyContainer.transform.GetChild(i).TryGetComponent<Enemy>(out Enemy enemy))
            {
                if(enemy.gameObject.activeInHierarchy)
                {
                    _enemyAmount++;
                    EnemyCountChanged?.Invoke(EnemyAmount, MaxEnemyCount);
                }
            }
        }
    }

    private void ShowLoseScreen()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Time.timeScale = 0f;
        _loseScreen.SetActive(true);
    }
}
