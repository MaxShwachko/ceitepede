using UnityEngine;

//This class should be abstract with also abstract Move() method. 
//It isn't because abstract class can't be added to game object as component.
//Base class for all moving patterns. Every pattern includes speed and it's own
//realization of moveing alghoritm per frame
public class MovingPattern : MonoBehaviour
{
    public float MovementSpeed;

    public virtual void Move() { }

    protected virtual void Update()
    {
        Move();
    }
}
