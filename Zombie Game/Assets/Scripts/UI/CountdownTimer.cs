using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public Text countdowntext;

    public int minutes;
    public int sec;

    int totalSeconds = 10;
    int TOTAL_SECONDS = 0;

    Color A = Color.red;

    void Start()
    {
        countdowntext.text = minutes + " : " + sec;
        if (minutes > 0)
            totalSeconds += minutes * 60;
        if (sec > 0)
            totalSeconds += sec;
        TOTAL_SECONDS = totalSeconds;
        StartCoroutine(second());
    }

    // Update is called once per frame
    void Update()
    {
        if (sec == 0 && minutes == 0)
        {
            countdowntext.color = A;
            StopCoroutine(second());
        }
    }
    IEnumerator second()
    {
        yield return new WaitForSeconds(1f);
        if (sec > 0)
            sec--;
        if (sec == 0 && minutes != 0)
        {
            sec = 60;
            minutes--;
        }
        countdowntext.text = minutes + " : " + sec;
      
        StartCoroutine(second());

        //countdowntext.color = A;

    }
}
