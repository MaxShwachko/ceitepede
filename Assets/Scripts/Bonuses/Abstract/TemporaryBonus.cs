using System;
using UnityEngine;

//Temporary bonus has not only value, but also duration of it's effect.
public abstract class TemporaryBonus : Bonus
{
    public float Duration;

    private void Start()
    {
        if (Duration < 0)
            throw new Exception("Bonus effect duration must be positive");
    }

    protected override void SetUpComponent(Component component)
    {
        base.SetUpComponent(component);

        if (component is TemporaryBonusEffect)
        {
            ((TemporaryBonusEffect)component).Duration = Duration;
        }
    }
}