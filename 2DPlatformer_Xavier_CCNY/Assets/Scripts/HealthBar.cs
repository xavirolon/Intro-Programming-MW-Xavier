using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // GLOBAL VARIABLES
    public Slider slider;   // slider UI variable

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // setting the max value of health bar
    public void SetMaxHealth(int health)    // void that takes in an integer health
    {
        slider.maxValue = health;   // set health to max value of slider component   
        slider.value = health;  // set value of slider component to health
    }

    // changing Health slider
    public void SetHealth(int health)
    {
        slider.value = health;  // change value parameter of slider to equal health
    }

}
