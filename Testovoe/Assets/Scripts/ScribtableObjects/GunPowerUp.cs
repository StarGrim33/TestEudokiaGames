using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/GunPowerUp", order = 1)]

public class GunPowerUp : Buffs
{
    [SerializeField] private float _value;
    [SerializeField] private float _duration;

    public override void ApplyPowerUP(GameObject target)
    {
        var gun = target.GetComponentInChildren<Gun>();
        gun.IncreaseFireRate(_value, _duration);
        Debug.Log("Gathered");
    }
}
