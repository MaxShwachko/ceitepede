//Life bonus effect heals it's target for adjusted value and then removes it's component from an object
public class LifeBonusEffect : BonusEffect
{
    private LifeController lifeController;

    void Awake()
    {
        lifeController = gameObject.GetComponent<LifeController>();

        if (lifeController == null)
            Destroy(this);
    }

    protected override void Affect()
    {
        lifeController.Heal((int)Value);
        Destroy(this);
    }
}