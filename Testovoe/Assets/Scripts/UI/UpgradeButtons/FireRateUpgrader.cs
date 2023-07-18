using UnityEngine;

public class FireRateUpgrader : UpgradeButton
{
    [SerializeField] private Gun _gun;

    private float _upgradeValuePerTab = 0.05f;

    public override void UpgradeWeapon()
    {
        _gun.UpgradeFireRate(_upgradeValuePerTab);
        Debug.Log("Successfull");
    }
}
