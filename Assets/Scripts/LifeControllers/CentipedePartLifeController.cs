using System;

//Reacts on centipede part life events, such as spawn mushroom when the part is shot down or destroy
//all the centipede when it's head reaches the bottom bound of the screen
public class CentipedePartLifeController : LifeController
{
    private CentipedePart centipedePart;
    private MushroomSpawner mushroomsSpawner;

    private void Awake()
    {
        mushroomsSpawner = FindObjectOfType<MushroomSpawner>();

        if (mushroomsSpawner == null)
            throw new Exception("Mushroom spawner component is missing");

        centipedePart = gameObject.GetComponent<CentipedePart>();

        if (centipedePart == null)
            throw new Exception("Centipede part component is missing");

        deathEventHandler += () =>
        {
            mushroomsSpawner.SpawnSingle(transform.position);
            DestroyOnePart();
        };
    }

    public void DestroyOnePart()
    {
        if (centipedePart.NextPart != null)
        {
            var nextCentipedePart = centipedePart.NextPart.GetComponent<CentipedePart>();
            if (nextCentipedePart != null)
            {
                nextCentipedePart.IsHead = true;
                nextCentipedePart.PrevPart = null;
            }
        }
        Destroy(gameObject);
    }

    public void DestroyAllParts()
    {
        if (centipedePart.NextPart != null)
        {
            var nextPartLifeController = centipedePart.NextPart.GetComponent<CentipedePartLifeController>();

            if (nextPartLifeController != null)
                nextPartLifeController.DestroyAllParts();
        }
        Destroy(gameObject);
    }
}
