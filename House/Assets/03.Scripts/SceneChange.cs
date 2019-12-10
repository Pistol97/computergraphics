using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public Image image;

    private float alpha = 0;
    // Start is called before the first frame update
    public void ChangeGameScene()
    {
        StartCoroutine(Fadeout());
    }

    public void GameMenuScene()
    {
        StartCoroutine(Fadein());
        SceneManager.LoadScene("Base");
    }

    public void GameQuitScene()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
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


    IEnumerator Fadeout()
    {
        image.enabled = true;
        while(alpha < 1.0f)
        {
            alpha += Time.deltaTime;
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            yield return null;
        }
        SceneManager.LoadScene("1Stage");
    }
}
