using UnityEngine;

public class DamageUpgrader : UpgradeButton
{
    [SerializeField] private GunBullet _bullet;

    private int _damageUpgradePerTab = 5;

    public override void UpgradeWeapon()
    {
        _bullet.UpgradeDamage(_damageUpgradePerTab);
        Debug.Log("Successfull");
    }
}
