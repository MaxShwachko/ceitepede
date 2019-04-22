using UnityEngine;

//Any centipede part changes it's moving direction when collides with nushrooms or any othe objects, which are a "NeutralUnit"s
public class CentipedeCollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var movingPattern = gameObject.GetComponent<MovingPattern>();

        if (collision.gameObject.layer == LayerMask.NameToLayer("NeutralUnit") &&
            movingPattern is CentipedeHeadMovingPattern)
        {
            ((CentipedeHeadMovingPattern)movingPattern).ChangeDirection();
        }
    }
}
