using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _menuPanel;

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        StateManager.Instance.SetState(GameState.Paused);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        StateManager.Instance.SetState(GameState.Gameplay);
    }

    public void OpenUgradeMenu(GameObject nextPanel)
    {
        _menuPanel.SetActive(false);
        nextPanel.SetActive(true);        
        StateManager.Instance.SetState(GameState.Paused);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
