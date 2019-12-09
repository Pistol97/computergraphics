using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    [SerializeField] private GameObject light;
    private bool lightOn = true;
    public bool LightOn
    {
        get { return lightOn; }
    }
   
    public void turnOn()
    {
        lightOn = true;
        light.SetActive(lightOn);
    }
    
    public void turnOff()
    {
        lightOn = false;
        light.SetActive(lightOn);
    }
}
