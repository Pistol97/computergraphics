using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public Image image;

    void fadeIn()
    {
        image.CrossFadeAlpha(1, 2, false);
    }

    // Start is called before the first frame update
    public void ChangeGameScene()
    {
        image.canvasRenderer.SetAlpha(0.0f);
        fadeIn();
        SceneManager.LoadScene("1Stage");
       
    }

    public void GameMenuScene()
    {
        SceneManager.LoadScene("Base");
    }

    public void GameQuitScene()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
