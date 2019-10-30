using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public string PlayLevel;

    public void Play()
    {
        SceneManager.LoadScene(PlayLevel);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
