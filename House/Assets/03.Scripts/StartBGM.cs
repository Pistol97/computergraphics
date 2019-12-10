using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartBGM : MonoBehaviour
{
    [SerializeField] private AudioSource bgm;
    public AudioClip clip;
    public Image image;

    private float alpha = 1.0f;
    bool isChanged = false;
    void Start()
    {
        StartCoroutine(Fadein());
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

    IEnumerator Fadein()
    {
        while (alpha > 0.0f)
        {
            alpha -= Time.deltaTime;
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            yield return null;
        }
        image.enabled = false;
    }

}

