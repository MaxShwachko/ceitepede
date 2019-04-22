using System;
using UnityEngine;

//All of the centipede parts refers to its previos and next parts. It's needed for moving and destruction.
//Depending on IsHead property, every part can change it's moving pattern.
public class CentipedePart : MonoBehaviour
{
    public event Action OnGoalReached;

    public GameObject NextPart;
    public GameObject PrevPart;

    private CentipedeMovingPattern movingPattern;
    private bool isHead;

    public bool IsHead
    {
        get { return isHead; }
        set
        {
            isHead = value;
            var speed = movingPattern.MovementSpeed;
            Destroy(movingPattern);
            movingPattern = value 
                ? gameObject.AddComponent<CentipedeHeadMovingPattern>() 
                : (CentipedeMovingPattern)gameObject.AddComponent<CentipedePartMovingPattern>();
            movingPattern.MovementSpeed = speed;
            movingPattern.OnLowerBoundReached += () => OnGoalReached?.Invoke();
        }
    }

    private void Awake()
    {
        movingPattern = gameObject.GetComponent<CentipedeMovingPattern>();

        if (movingPattern == null)
            throw new Exception("Centipede moving pattern component is missing");
    }
}