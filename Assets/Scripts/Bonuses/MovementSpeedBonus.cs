//Movement speed bonus has effect of MovementSpeedIncreeseEffect type, that it adds to a game object as a component
public class MovementSpeedBonus : TemporaryBonus
{
    private void Start()
    {
        effectType = typeof(MovementSpeedIncreeseEffect);
    }
}
