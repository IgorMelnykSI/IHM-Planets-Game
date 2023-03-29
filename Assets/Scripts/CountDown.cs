using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    private float timeLeft = 180f;

    public TextMeshProUGUI minutes;

    public TextMeshProUGUI seconds;



    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0 && GameManager.Instance.gameStarted)
        {
            UpdateTimer();
        }

        if (timeLeft < 0)
        {
            Debug.Log("Game is over");
        }
    }

    void UpdateTimer()
    {
        timeLeft -= Time.deltaTime;

        minutes.SetText(((int)timeLeft / 60).ToString() + ":");
        int modulo = (int)timeLeft % 60;
        string second = modulo < 10 ? "0" + modulo.ToString() : modulo.ToString();
        seconds.SetText(second);
    }
}
