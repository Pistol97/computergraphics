using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    [SerializeField] private GameObject light;
    [SerializeField] private GameObject book ;

    [SerializeField] private AudioSource click;
    private bool lightOn = true;
    public bool LightOn
    {
        get { return lightOn; }
    }
   
    public void turnOn()
    {
        lightOn = true;
        light.SetActive(lightOn);
        click.Play();
    }
    
    public void turnOff()
    {
        lightOn = false;
        light.SetActive(lightOn);
        click.Play();
        book.SetActive(true);
    }
}
