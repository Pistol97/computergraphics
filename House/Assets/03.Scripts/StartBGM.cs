using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBGM : MonoBehaviour
{
    [SerializeField] private AudioSource bgm;
    public AudioClip clip;

    bool isChanged = false;
    void Start()
    {
        bgm = GetComponent<AudioSource>();
        bgm.clip = clip;
    }
    void Update()
    {
        if (RedBook.StartHorror == true && isChanged == false)
        {
            bgm.Play();
            isChanged = true;
        }
    }
}

