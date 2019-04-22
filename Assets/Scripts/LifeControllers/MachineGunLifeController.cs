using System;

//Does nothing besides of rising event whenever player heals, takes damage or dies
public class MachineGunLifeController : LifeController
{
    public event Action OnDeath;
    public event Action OnDamageTaken;
    public event Action OnHeal;

    private void Awake()
    {
        deathEventHandler += () =>
            {
                OnDeath?.Invoke();
            };
        healEventHandler += () =>
        {
            OnHeal?.Invoke();
        };
        damageTakenEventHandler += () =>
        {
            OnDamageTaken?.Invoke();
        };
    }
}