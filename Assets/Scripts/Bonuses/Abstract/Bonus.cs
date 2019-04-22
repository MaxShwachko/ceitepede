using System;
using UnityEngine;

//Base class for all kinds of bonuses. Every bonus has it's own BonusEffect, 
//which can be added to any game object as a component and affect it.
public abstract class Bonus : MonoBehaviour
{
    public float Value;

    protected Type effectType;

    public void Affect(params GameObject[] targets)
    {
        foreach (var target in targets)
        {
            var component = target.AddComponent(effectType);
            SetUpComponent(component);
        }
    }

    protected virtual void SetUpComponent(Component component)
    {
        ((BonusEffect)component).Value = Value;
    }
}
