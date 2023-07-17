using UnityEngine;

public class ScreenShower : MonoBehaviour
{
    [SerializeField] private GameObject _loseScreen;
    [SerializeField] private EnemyCounter _enemyCounter;

    private void OnEnable()
    {
        _enemyCounter.MaxEnemyCountReached += OnMaxEnemyCountReached;
    }

    private void OnDisable()
    {
        _enemyCounter.MaxEnemyCountReached -= OnMaxEnemyCountReached;
    }

    private void OnMaxEnemyCountReached()
    {
        ShowLoseScreen();
    }

    private void ShowLoseScreen()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Time.timeScale = 0f;
        _loseScreen.SetActive(true);
    }
}
