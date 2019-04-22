using System;
using UnityEngine;

//Instantiates centipedes and detects it's lifetime. Rises appropriate events
public class CentipedeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject CentipedePartPrefab;
    [SerializeField]
    private int MinimalPartsInCentidepe;

    private float spriteWidth;
    private bool IsSpawned;

    public event Action<GameObject> OnSpawn;
    public event Action OnAllPartsDestroyed;

    public int LastSpawnPartsCount { get; private set; }
    public float CentipedeSpeed
    {
        get { return CentipedePartPrefab.GetComponent<MovingPattern>().MovementSpeed; }
        set { CentipedePartPrefab.GetComponent<MovingPattern>().MovementSpeed = value; }
    }

    private void Start()
    {
        if (CentipedePartPrefab == null)
            throw new Exception("Centipede part prefab is missing");

        if (MinimalPartsInCentidepe < 1)
            throw new Exception("Minimal parts in centipede count can't be less than 1");

        if (CentipedePartPrefab.GetComponent<CentipedePart>() == null)
            throw new Exception("Centipede part component is missing");

        if (CentipedePartPrefab.GetComponent<MovingPattern>() == null)
            throw new Exception("Moving pattern component is missing");

        var spriteRenderer = CentipedePartPrefab.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
            throw new Exception("Sprite renderer component is missing");

        spriteWidth = spriteRenderer.sprite.bounds.size.x;
        IsSpawned = false;
    }

    private void Update()
    {
        CheckForAliveParts();
    }

    public void Spawn(int partsCount)
    {
        if (partsCount < MinimalPartsInCentidepe)
            partsCount = MinimalPartsInCentidepe;

        var currentPart = Spawn(transform.position, true);

        for (int i = 1; i < partsCount; i++)
        {
            var spawnPosition = transform.position - new Vector3(spriteWidth, 0, 0);
            var newPart = Spawn(spawnPosition, false);
            newPart.GetComponent<CentipedePart>().PrevPart = currentPart;
            currentPart.GetComponent<CentipedePart>().NextPart = newPart;
            currentPart = newPart;
        }

        if (partsCount > 1)
            LastSpawnPartsCount = partsCount;
    }

    private GameObject Spawn(Vector3 position, bool isHead)
    {
        var newPart = Instantiate(CentipedePartPrefab, position, Quaternion.identity, gameObject.transform);
        newPart.GetComponent<CentipedePart>().IsHead = isHead;
        OnSpawn?.Invoke(newPart);
        IsSpawned = true;

        return newPart;
    }

    private void CheckForAliveParts()
    {
        if (gameObject.transform.childCount == 0 && IsSpawned)
        {
            IsSpawned = false;
            OnAllPartsDestroyed?.Invoke();
        }
    }
}