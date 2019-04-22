using UnityEngine;

//Spawns only ants enemies (for now) with certain delay
public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject antPrefab;

    public float SpawnCooldown { get; set; }

    private float spawwnDelay;

    void Start()
    {
        if (antPrefab == null)
            throw new System.Exception("Ant prefab is missing");
    }

    void Update()
    {
        spawwnDelay += Time.deltaTime;

        if (spawwnDelay >= SpawnCooldown)
        {
            SpawnAnt();
            spawwnDelay = 0;
        }
    }

    private void SpawnAnt()
    {
        Instantiate(antPrefab, new Vector3(Random.Range(GameBoundsDetector.LeftBound.x, GameBoundsDetector.RightBound.x), 
                    GameBoundsDetector.UpperBound.y, transform.position.z), Quaternion.identity, gameObject.transform);
    }
}
