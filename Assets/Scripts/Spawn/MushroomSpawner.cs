using UnityEngine;

//Instantiates mushrooms in determined or random positions on the screen upon request
public class MushroomSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject MushroomPrefab;

    private float spriteHalfWidth;
    private float spriteHalfHeight;

    public float BonusDropChance
    {
        get { return MushroomPrefab.GetComponent<MushroomLifeController>().BonusDropChance; }
        set { MushroomPrefab.GetComponent<MushroomLifeController>().BonusDropChance = value; }
    }

    void Start()
    {
        if (MushroomPrefab == null)
            throw new System.Exception("Mushroom prefab is missing");

        if (MushroomPrefab.GetComponent<MushroomLifeController>() == null)
            throw new System.Exception("Mushroom life controller component is missing");

        spriteHalfWidth = MushroomPrefab.GetComponent<SpriteRenderer>().sprite.bounds.extents.x;
        spriteHalfHeight = MushroomPrefab.GetComponent<SpriteRenderer>().sprite.bounds.extents.y;
    }

    public void SpawnMultipleInRandomPositions(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var position = new Vector3
                (Random.Range((int)(GameBoundsDetector.LeftBound.x + spriteHalfWidth), (int)(GameBoundsDetector.RightBound.x - spriteHalfWidth)),
                Random.Range((int)(GameBoundsDetector.LowerBound.y + spriteHalfHeight), (int)(GameBoundsDetector.UpperBound.y - spriteHalfHeight)),
                0);

            SpawnSingle(position);
        }
    }

    public void SpawnSingle(Vector3 position)
    {
        if (GameBoundsDetector.IsInGameBounds(position))
            Instantiate(MushroomPrefab, Vector3Int.FloorToInt(position), Quaternion.identity, gameObject.transform);
    }

}
