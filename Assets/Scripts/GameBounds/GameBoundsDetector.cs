using System;
using UnityEngine;

//Detects all the game bounds every frame. It's needed to react to game window size changes.
//Can also be used to correct any object position in accordance with current game bounds.
public class GameBoundsDetector : MonoBehaviour
{
    public float PlayerZoneToGameRatio;

    public static Vector3 UpperBound { get; private set; }
    public static Vector3 LowerBound { get; private set; }
    public static Vector3 LeftBound { get; private set; }
    public static Vector3 RightBound { get; private set; }
    public static Vector3 PlayerZoneUpperBound { get; private set; }

    void Awake()
    {
        if (PlayerZoneToGameRatio < 0 || PlayerZoneToGameRatio > 1)
            throw new Exception("Player zone ratio must be in [0,1] range");

        DetectBounds();
    }

    private void Update()
    {
        DetectBounds();
    }

    public static bool IsInGameBounds(Vector3 position)
    {
        return position.x > LeftBound.x && position.x < RightBound.x &&
               position.y > LowerBound.y && position.y < UpperBound.y;
    }

    public static void KeepInGameBounds(GameObject obj)
    {
        KeepInBounds(obj, LeftBound, UpperBound, RightBound, LowerBound);
    }

    public static void KeepInPlayerZoneBounds(GameObject obj)
    {
        KeepInBounds(obj, LeftBound, PlayerZoneUpperBound, RightBound, LowerBound);
    }

    private static void KeepInBounds(GameObject obj, Vector3 left, Vector3 upper, Vector3 right, Vector3 lower)
    {
        var halfWidth = obj.GetComponent<SpriteRenderer>().sprite.bounds.extents.x;
        var halfHeight = obj.GetComponent<SpriteRenderer>().sprite.bounds.extents.y;

        var restrictX = Mathf.Clamp(obj.transform.position.x, left.x + halfWidth, right.x - halfWidth);
        var restrictY = Mathf.Clamp(obj.transform.position.y, lower.y + halfHeight, upper.y - halfHeight);

        obj.transform.position = new Vector3(restrictX, restrictY, obj.transform.position.z);
    }

    private void DetectBounds()
    {
        var screenRatio = (float)Screen.width / (float)Screen.height;

        UpperBound = new Vector3(0, Camera.main.orthographicSize + 1, 0);
        LowerBound = new Vector3(0, -Camera.main.orthographicSize, 0);
        RightBound = new Vector3(Camera.main.orthographicSize * screenRatio, 0, 0);
        LeftBound = new Vector3(-Camera.main.orthographicSize * screenRatio, 0, 0);
        PlayerZoneUpperBound = new Vector3(0, LowerBound.y + 2 * Camera.main.orthographicSize * PlayerZoneToGameRatio, 0);
    }
}