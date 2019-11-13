using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public static GameManager Instance;

    [Header("Propertys")]
    [HideInInspector]
    public bool Paused = false;
    public float RoundTimerDuration;
    private float RoundTimer;
    private float Kills;

    [Header("References")]
    public GameObject PauseMenu;
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI KillText;

    public float CurrentKills { get => Kills;
        set {
            Kills = value;
            KillText.text = value.ToString();
        } }

    // Start is called before the first frame update
    void Start()
    {
        RoundTimer = RoundTimerDuration;
        TimerText.text = FormatTime(RoundTimer);
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Assert(!Instance);
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (Paused)
            {
                UnPause();
            }
            else
            {
                Pause();
            }
        }

        if (!Paused)
        {
            RoundTimer -= Time.deltaTime;
            TimerText.text = FormatTime(RoundTimer);
        }
    }

    public string FormatTime(float time)
    {
        int minutes = (int)time / 60;
        int seconds = (int)time - 60 * minutes;
        int milliseconds = (int)(1000 * (time - minutes * 60 - seconds));
        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
        Paused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        Paused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
