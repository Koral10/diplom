using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Health playerHealth;
    public bool buttom;

    private void Srart()
    {
        SetMaxHealth(playerHealth.maxHealth);
    }

    private void Update()
    {
        SetHealth(playerHealth.health);
        if (slider.value == 0)
        {

        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
