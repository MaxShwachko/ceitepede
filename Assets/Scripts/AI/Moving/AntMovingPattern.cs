using UnityEngine;

//Ant moves according to forward moving pattern, but also initiates mushroom spawn time to time
public class AntMovingPattern : ForwardMovingPattern
{
    [SerializeField]
    private float mushroomSpawnChance;

    private MushroomSpawner mushroomSpawner;

    private void Start()
    {
        if (mushroomSpawnChance < 0 || mushroomSpawnChance > 1)
            throw new System.Exception("Mushroom spawn chance must be in [0,1] range");

        mushroomSpawner = FindObjectOfType<MushroomSpawner>();

        if (mushroomSpawner == null)
            throw new System.Exception("Mushroom spawner component is missing");
    }

    public override void Move()
    {
        base.Move();

        var randomValue = Random.Range(0, 100);
        if (randomValue <= mushroomSpawnChance * 100)
        {
            mushroomSpawner.SpawnSingle(transform.position);
        }
    }
}
