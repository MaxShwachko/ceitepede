using System;
using UnityEngine;

//Life controller is a base class, that provides delegates to react on HealthManager events
public class LifeController : MonoBehaviour
{
    [SerializeField]
    private int StartHealth;

    public int Health { get { return healthManager.Health; } }

    private HealthManager healthManager;
    protected Action damageTakenEventHandler;
    protected Action deathEventHandler;
    protected Action healEventHandler;

    void Start()
    {
        healthManager = new HealthManager(StartHealth);

        if (damageTakenEventHandler != null)
            healthManager.OnDamageTaken += damageTakenEventHandler;

        if (deathEventHandler != null)
            healthManager.OnDeath += deathEventHandler;

        if (healEventHandler != null)
            healthManager.OnHeal += healEventHandler;
    }

    public void GetDamage(int damage)
    {
        healthManager.GetDamage(damage);
    }

    public void Heal(int value)
    {
        healthManager.Heal(value);
    }
}