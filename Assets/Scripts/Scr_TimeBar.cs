using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_TimeBar : MonoBehaviour
{
    public Slider slider;

    public void setMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public float getMaxHealth()
    {
        return slider.maxValue;
    }

    public void setHealth(float health)
    {
        slider.value = health;
    }
}
