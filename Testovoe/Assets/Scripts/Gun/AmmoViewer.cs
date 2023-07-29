using TMPro;
using UnityEngine;
using Zenject;

public class AmmoViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text _muzzleText;
    [SerializeField] private Gun _gun;

    [Inject]
    public void Construct(TMP_Text text, Gun gun)
    {
        _muzzleText = text;
        _gun = gun;
    }

    private void Update()
    {
        _muzzleText.text = _gun.BulletsLeft.ToString();
    }
}
