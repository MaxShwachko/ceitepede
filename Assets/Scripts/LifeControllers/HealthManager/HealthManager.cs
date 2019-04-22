using System;

//HealthManager conrolls the lifetime of any alive unit and rises appropriate event.
public class HealthManager
{
    public event Action OnDamageTaken;
    public event Action OnHeal;
    public event Action OnDeath;

    public int Health { get; private set; }

    public HealthManager(int health)
    {
        if (health < 1)
            throw new ArgumentException("Health value can't be less than 1");

        Health = health;        
    }

    public void GetDamage(int damage)
    {
        if (Health - damage > 0)
        {
            Health -= damage;
            OnDamageTaken?.Invoke();
        }
        else
            OnDeath?.Invoke();
    }

    public void Heal(int value)
    {
        if (value > 0)
        {
            Health += value;
            OnHeal?.Invoke();
        }
    }
}