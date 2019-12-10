using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public Image image;
    private float alpha = 0;

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
            StartCoroutine(Fadeout());
            
        }
        if (check == 19 && SceneManager.GetActiveScene().name == "2Stage")
        {
            StartCoroutine(Fadeout2());
        }
    }

    IEnumerator Fadeout()
    {
        image.enabled = true;
        while (alpha < 1.0f)
        {
            alpha += Time.deltaTime;
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            yield return null;
        }
        SceneManager.LoadScene("2Stage");
    }

    IEnumerator Fadeout2()
    {
        image.enabled = true;
        while (alpha < 1.0f)
        {
            alpha += Time.deltaTime;
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            yield return null;
        }
        SceneManager.LoadScene("Ending");
    }

}
