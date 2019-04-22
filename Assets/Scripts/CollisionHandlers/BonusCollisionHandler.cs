using System;
using UnityEngine;

//Bonus affects the target with it's Bonus instance
public class BonusCollisionHandler : MonoBehaviour
{
    private Bonus bonus;

    private void Start()
    {
        bonus = gameObject.GetComponent<Bonus>();

        if (bonus == null)
            throw new Exception("Bonus component is missing");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            bonus.Affect(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
