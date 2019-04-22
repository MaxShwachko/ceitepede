using UnityEngine;

//Temporary bonus effects can affect on any game object only for limited amount of time, after that objects properties will be restored.
public abstract class TemporaryBonusEffect : BonusEffect
{
    public float Duration { get; set; }

    protected abstract void RestoreState();

    void Update()
    {
        if (Duration > 0)
            Duration -= Time.deltaTime;
        else
        {
            RestoreState();
            Destroy(this);
        }
    }
}