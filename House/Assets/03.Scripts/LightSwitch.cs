using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LightSwitch : MonoBehaviour
{
    [SerializeField] private GameObject light;
    [SerializeField] private GameObject book ;

    [SerializeField] private AudioSource click;
    private bool lightOn = true;
    private int check = 0;
    public bool LightOn
    {
        get { return lightOn; }
    }
   
    public void turnOn()
    {
        check++;
        lightOn = true;
        light.SetActive(lightOn);
        click.Play();
        Debug.Log(check);
    }
    
    public void turnOff()
    {
        check++;
        lightOn = false;
        light.SetActive(lightOn);
        click.Play();
        book.SetActive(true);
        Debug.Log(check);
    }

    public void Update()
    {
        if(check==2 && SceneManager.GetActiveScene().name=="1Stage")
        {
            SceneManager.LoadScene("2Stage");
           
        }
        if (check == 19 && SceneManager.GetActiveScene().name == "2Stage")
        {
            SceneManager.LoadScene("Ending");
        }
    }
}
