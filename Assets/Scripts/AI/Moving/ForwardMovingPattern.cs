using UnityEngine;

//Objects with such moving pattern moves straight in one of avaliabe directions. When it goes out of camera vision, it destroyes
public class ForwardMovingPattern : MovingPattern
{
    public MovementDirection Direction;

    public override void Move()
    {
        Vector3 positionShift;
        switch (Direction)
        {
            case MovementDirection.Left:
                positionShift = new Vector3(-MovementSpeed * Time.deltaTime, 0, transform.position.z);
                break;
            case MovementDirection.Right:
                positionShift = new Vector3(MovementSpeed * Time.deltaTime, 0, transform.position.z);
                break;
            case MovementDirection.Up:
                positionShift = new Vector3(0, MovementSpeed * Time.deltaTime, transform.position.z);
                break;
            case MovementDirection.Down:
                positionShift = new Vector3(0, -MovementSpeed * Time.deltaTime, transform.position.z);
                break;
            default:
                positionShift = new Vector3();
                break;
        }
        transform.position += positionShift;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
