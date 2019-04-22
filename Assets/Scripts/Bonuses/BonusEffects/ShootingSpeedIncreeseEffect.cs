//Shooting speed bonus effect works similarly to MovementSpeedIncreeseEffect,
//but buffs speed of shooting bullets instead of movement speed
public class ShootingSpeedIncreeseEffect : TemporaryBonusEffect
{
    private MovingPattern bulletMovingPattern;

    void Awake()
    {
        var inputController = gameObject.GetComponent<PlayerInputController>();

        if (inputController == null)
            Destroy(this);

        var bulletPrefab = inputController.bulletPrefab;

        if (bulletPrefab == null)
            Destroy(this);

        bulletMovingPattern = bulletPrefab.GetComponent<MovingPattern>();

        if (bulletPrefab == null)
            Destroy(this);
    }

    protected override void Affect()
    {
        bulletMovingPattern.MovementSpeed += Value;
    }

    protected override void RestoreState()
    {
        bulletMovingPattern.MovementSpeed -= Value;
    }
}