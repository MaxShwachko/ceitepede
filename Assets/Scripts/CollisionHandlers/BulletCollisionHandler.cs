using System;
using UnityEngine;

//Bullet trying to deal deal damage to the object whitch if collides with
public class BulletCollisionHandler : MonoBehaviour
{
    public int Damage;

    private void Start()
    {
        if (Damage < 0)
            throw new Exception("Bullet damage must be more than 0.");
    }

    private void OnTriggerEnter2D(Collider2D source)
    {
        var sourceLifeController = source.gameObject.GetComponent<LifeController>();

        if (sourceLifeController != null)
        {
            sourceLifeController.GetDamage(Damage);
        }

        Destroy(gameObject);
    }
}
