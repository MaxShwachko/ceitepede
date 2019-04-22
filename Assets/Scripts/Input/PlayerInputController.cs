using UnityEngine;

//Defines players input and reacts to it.
public class PlayerInputController : MonoBehaviour
{
    public float MovementSpeed;
    public GameObject bulletPrefab;

    void Update ()
    {
        if (IsMooving())
        {
            Move();
            GameBoundsDetector.KeepInPlayerZoneBounds(gameObject);
        }

        if (IsShooting())
            Shoot();
	}

    private void Move()
    {
        var positionShift = new Vector3(Input.GetAxis("Horizontal") * MovementSpeed * Time.deltaTime, Input.GetAxis("Vertical") * MovementSpeed * Time.deltaTime);
        transform.position += positionShift;
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

    private bool IsMooving()
    {
        return Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
    }

    private bool IsShooting()
    {
        return Input.GetButtonDown("Fire1");
    }
}
