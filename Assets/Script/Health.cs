using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public int health;
    public int maxHealth;

    public void TakeHit(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            gameObject.SetActive(false);
            health = 0;
        }
    }

    public void Sethealt(int bonusHealt)
    {
        if (health == 0)
        {
            bonusHealt = 0;
        }
        health += bonusHealt;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
