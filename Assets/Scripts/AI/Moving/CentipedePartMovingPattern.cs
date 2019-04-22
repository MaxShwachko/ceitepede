using UnityEngine;

//All the part of centipede except the head moves straight to its previous part all the time
public class CentipedePartMovingPattern : CentipedeMovingPattern
{
    private GameObject prevPart;

    void Start()
    {
        var centipedePart = gameObject.GetComponent<CentipedePart>();
        
        if (centipedePart == null)
            throw new System.Exception("Centipede part component is missing");
        
        prevPart = centipedePart.PrevPart;
    }

    public override void Move()
    {
        if (prevPart != null)
        {
            var positionShift = MovementSpeed * Time.deltaTime * (prevPart.transform.position - transform.position);
            transform.position += positionShift;
        }
    }
}