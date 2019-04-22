using System;
using UnityEngine;

//Player's machine gun takes damage every time when collides with "Enemy"
public class MachineGunCollisionHandler : MonoBehaviour
{
    private LifeController lifeController;

    private void Start()
    {
        lifeController = gameObject.GetComponent<LifeController>();

        if (lifeController == null)
            throw new Exception("Life controller component is missing");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            lifeController.GetDamage(1);
        }
    }
}
