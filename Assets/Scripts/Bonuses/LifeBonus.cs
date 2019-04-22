//Life bonus has effect of LifeBonusEffect type, that it adds to a game object as a component
public class LifeBonus : Bonus
{
    private void Start()
    {
        effectType = typeof(LifeBonusEffect);
    }
}