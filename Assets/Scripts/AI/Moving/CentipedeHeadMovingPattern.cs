using System;
using UnityEngine;

//Head centipede moves in such way: if direction is left or right, it moves forward (UpdatePosition())
//untill reaches one of game bounds (CheckForBounds()) or collides with mushroom (that manages from CentipedePartCollisionHandler class).
//After that is ChangesDirection(), moves down for downMovingDistanceBeforeTurn and changes direction once again (to the left or to the right).
//If lower bound of the window is reached, it rises appropriate event on base class. NormalizePosition() is needed to vertical position was integer
//when moving horizontal
public class CentipedeHeadMovingPattern : CentipedeMovingPattern
{
    private MovementDirection currentDirection;
    private MovementDirection lastHorizontalDirection;
    private float downMovingDistanceBeforeTurn;
    private float currentDownDistance;

    void Start()
    {
        var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
            throw new Exception("Sprite renderer component is missing");

        downMovingDistanceBeforeTurn = spriteRenderer.sprite.bounds.size.y;
        NormalizePosition();
        currentDirection = MovementDirection.Down;
    }

    public override void Move()
    {
        var shift = MovementSpeed * Time.deltaTime;
        UpdatePosition(shift);
        CheckForBounds();
    }

    public void ChangeDirection()
    {
        switch (currentDirection)
        {
            case MovementDirection.Left:
            case MovementDirection.Right:
                {
                    currentDownDistance = downMovingDistanceBeforeTurn;
                    lastHorizontalDirection = currentDirection;
                    currentDirection = MovementDirection.Down;
                    break;
                }
            case MovementDirection.Up:
            case MovementDirection.Down:
                currentDirection = lastHorizontalDirection == MovementDirection.Right
                                 ? MovementDirection.Left
                                 : MovementDirection.Right;
                break;
            default:
                break;
        }
    }

    private void UpdatePosition(float shift)
    {
        switch (currentDirection)
        {
            case MovementDirection.Left:
                transform.position += new Vector3(-shift, 0, 0);
                break;
            case MovementDirection.Right:
                transform.position += new Vector3(shift, 0, 0);
                break;
            case MovementDirection.Up:
                transform.position += new Vector3(0, shift, 0);
                break;
            case MovementDirection.Down:
                {
                    if (currentDownDistance > shift)
                    {
                        transform.position -= new Vector3(0, shift, 0);
                        currentDownDistance -= shift;
                    }
                    else
                    {
                        NormalizePosition();
                        ChangeDirection();
                    }
                    break;
                }
            default:
                break;
        }
    }

    private void CheckForBounds()
    {
        if (transform.position.y <= GameBoundsDetector.LowerBound.y)
            RiseOnLowerBoundReachedEvent();

        if (!GameBoundsDetector.IsInGameBounds(transform.position))
        {
            GameBoundsDetector.KeepInGameBounds(gameObject);
            ChangeDirection();
        }
    }

    private void NormalizePosition()
    {
        transform.position = new Vector3(transform.position.x, Mathf.FloorToInt(transform.position.y), transform.position.z);
    }
}
