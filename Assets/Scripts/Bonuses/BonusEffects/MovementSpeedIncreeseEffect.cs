//Temporary increaces player moving speed, after that restroes old value and destroys itself (as a component)
public class MovementSpeedIncreeseEffect : TemporaryBonusEffect
{
    private PlayerInputController inputController;

    void Awake()
    {
        inputController = gameObject.GetComponent<PlayerInputController>();

        if (inputController == null)
            Destroy(this);
    }

    protected override void Affect()
    {
        inputController.MovementSpeed += Value;
    }

    protected override void RestoreState()
    {
        inputController.MovementSpeed -= Value;
    }
}