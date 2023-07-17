using UnityEngine;
using UnityEngine.EventSystems;

public class MenuOpener : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            StateManager.Instance.SetState(GameState.Paused);
            _panel.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }
}
