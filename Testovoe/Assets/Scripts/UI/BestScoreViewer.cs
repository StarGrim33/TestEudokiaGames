using TMPro;
using UnityEngine;

public class BestScoreViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _text.text = $"Лучшая волна: {PlayerData.BestWave}".ToString();  
    }

    public void ShowBestScore(GameObject panel)
    {
        panel.SetActive(true);
    }
}
