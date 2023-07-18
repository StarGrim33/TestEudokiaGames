using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void Play(int sceneIndex)
    {
        PlayerData.CurrentWave = 0;
        SceneManager.LoadScene(sceneIndex);
    }
}
