using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public float TimeLeft;
    public bool TImerOn = false;
    [SerializeField] TMP_Text TimerTxt;
    // Start is called before the first frame update
    void Start()
    {
        TImerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (TImerOn)
        {
            if(TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                Debug.Log("You lose");
                TimeLeft = 0;
                TImerOn = false;
                SceneManager.LoadScene(5);
            }
        }
    }
    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
