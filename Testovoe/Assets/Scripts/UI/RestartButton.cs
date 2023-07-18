using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void Restart()
    {
        var sceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerData.CurrentWave = 0;
        SceneManager.LoadScene(sceneIndex);
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene(0);
    }
}
