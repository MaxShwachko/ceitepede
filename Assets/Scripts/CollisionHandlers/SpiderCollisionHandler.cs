using UnityEngine;

//Spider reacts for collision with trying to eat a mushroom (Destroy(collision.gameObject)) with certain chance
public class SpiderCollisionHandler : MonoBehaviour
{
    [SerializeField]
    private float mushroomEatingChance;

    private void Start()
    {
        if (mushroomEatingChance < 0 || mushroomEatingChance > 1)
            throw new System.Exception("Mushroom eating chane must be in [0,1] range");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("NeutralUnit"))
        {
            var randomValue = Random.Range(0, 100);
            if (randomValue <= mushroomEatingChance * 100)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
