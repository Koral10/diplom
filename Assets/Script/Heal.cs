using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Heal : MonoBehaviour
{
    public int collisionHeal = 100;
    public string collisionTag;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == collisionTag)
        {
            Health health = coll.gameObject.GetComponent<Health>();
            health.Sethealt(collisionHeal);
        }
    }
}
