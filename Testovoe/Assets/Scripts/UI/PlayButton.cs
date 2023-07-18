using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void Play(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
