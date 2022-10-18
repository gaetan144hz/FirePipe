using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;

    public void SetMaxHealth(int health)
    {
        Debug.Log("oui");
    }

    public void SetHealth(int health)
    {
        Debug.Log("gdg");
    }
}
