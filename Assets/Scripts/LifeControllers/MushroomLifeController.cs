using UnityEngine;

//Controlls every mushroom lifetime. When it's shot down, there is a chance that random bonus will be droped
public class MushroomLifeController : LifeController
{
    public float BonusDropChance;

    private void Awake()
    {
        if (BonusDropChance < 0 || BonusDropChance > 1)
            throw new System.Exception("Bonus spawn chance must be in [0,1] range");

        deathEventHandler = () =>
        {
            TryDropBonus();
            Destroy(gameObject);
        };
    }

    private void TryDropBonus()
    {
        var randomValue = Random.Range(0, 100);
        if (randomValue <= BonusDropChance * 100)
        {
            var bonusesSpawner = FindObjectOfType<BonusesSpawner>();
            if (bonusesSpawner != null)
            {
                bonusesSpawner.SpawnRandomBonus(transform.position);
            }
        }
    }
}
