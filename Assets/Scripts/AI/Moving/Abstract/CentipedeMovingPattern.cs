using System;

//Base class for all of centipede moving patterns (head and part).
//Detects when centipede reaches the lower bound of the screen,
//rises appropriate event and destroy all the part of concrete centipede
public class CentipedeMovingPattern : MovingPattern
{
    public event Action OnLowerBoundReached;

    protected void RiseOnLowerBoundReachedEvent()
    {
        OnLowerBoundReached?.Invoke();
        var lifeController = gameObject.GetComponent<CentipedePartLifeController>();

        if (lifeController == null)
            throw new Exception("Centipede part life controller component is missing");

        lifeController.DestroyAllParts();
    }
}
