using System.Collections.Generic;
using UnityEngine;

//Instantiates different bonus objects or random one upon request
public class BonusesSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject lifeBonusPrefab;
    [SerializeField]
    private GameObject movingSpeedBonusPrefab;
    [SerializeField]
    private GameObject shootingSpeedBonusPrefab;

    private List<GameObject> allPrefabs;

    private void Start()
    {
        if (lifeBonusPrefab == null)
            throw new System.Exception("Life bonus prefab is missing");

        if (movingSpeedBonusPrefab == null)
            throw new System.Exception("Movement speed bonus prefab is missing");

        if (shootingSpeedBonusPrefab == null)
            throw new System.Exception("Shooting speed bonus prefab is missing");

        allPrefabs = new List<GameObject>
        {
            lifeBonusPrefab,
            movingSpeedBonusPrefab,
            shootingSpeedBonusPrefab
        };
    }

    public void SpawnRandomBonus(Vector3 position)
    {
        var randomIndex = Random.Range(0, allPrefabs.Count);
        var randomBonusPrefab = allPrefabs[randomIndex];
        Spawn(randomBonusPrefab, position);
    }

    public void SpawnLifeBonus(Vector3 position)
    {
        Spawn(lifeBonusPrefab, position);
    }

    public void SpawnShootingSpeedBonusPrefab(Vector3 position)
    {
        Spawn(shootingSpeedBonusPrefab, position);
    }

    public void SpawnMovingSpeedBonus(Vector3 position)
    {
        Spawn(movingSpeedBonusPrefab, position);
    }

    private void Spawn(GameObject obj, Vector3 position)
    {
        Instantiate(obj, position, Quaternion.identity, transform);
    }
}