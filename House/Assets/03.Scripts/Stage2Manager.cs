using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Manager : MonoBehaviour
{
    [SerializeField] private AudioSource bgm;
    public AudioSource surprise;
    public AudioSource jumpScare;
    public AudioSource scream;
    public AudioSource sigh;
    public AudioClip audioClip;

    int lightCount = 0;
    public LightSwitch lightSwitch;
    public GameObject[] manneQuins;

    bool isChanged = false;
    bool isOn = false;
    bool isSwitched = false;
    void Start()
    {
        bgm.clip = audioClip;
    }

    void Update()
    {
        if (lightSwitch.LightOn == false && isChanged == false)
        {
            bgm.Play();
            isChanged = true;
            isOn = true;
        }

        if (lightSwitch.LightOn == true && isOn == true)
        {
            isOn = false;
            isSwitched = true;
            lightCount++;
        }

        else if (lightSwitch.LightOn == false)
            isOn = true;

        Debug.Log(lightCount.ToString());
        if (isSwitched)
        {
            isSwitched = false;
            switch (lightCount)
            {
                case 1:
                    manneQuins[0].SetActive(true);
                    surprise.Play();
                    break;
                case 2:
                    manneQuins[0].SetActive(false);
                    manneQuins[1].SetActive(true);
                    surprise.Play();
                    break;
                case 3:
                    manneQuins[1].SetActive(false);
                    manneQuins[2].SetActive(true);
                    surprise.Play();
                    break;
                case 4:
                    manneQuins[2].SetActive(false);
                    manneQuins[3].SetActive(true);
                    surprise.Play();
                    break;
                case 5:
                    //Walk_5
                    manneQuins[3].SetActive(false);
                    manneQuins[4].SetActive(true);
                    surprise.Play();
                    sigh.Play();
                    break;
                case 6:
                    manneQuins[4].SetActive(false);
                    manneQuins[5].SetActive(false);
                    surprise.Play();
                    break;
                case 7:
                    manneQuins[6].SetActive(true);
                    scream.Play();
                    break;
                case 8:
                    //Broken
                    manneQuins[6].SetActive(false);
                    manneQuins[7].SetActive(true);
                    surprise.Play();
                    break;
                case 9:
                    manneQuins[7].SetActive(false);
                    manneQuins[8].SetActive(true);
                    jumpScare.Play();
                    break;
                default:
                    break;
            }
        }
    }
}
