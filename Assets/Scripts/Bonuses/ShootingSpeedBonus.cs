//Shooting speed bonus has effect of ShootingSpeedIncreeseEffect type, that it adds to a game object as a component
public class ShootingSpeedBonus : TemporaryBonus
{
    private void Start()
    {
        effectType = typeof(ShootingSpeedIncreeseEffect);
    }
}
