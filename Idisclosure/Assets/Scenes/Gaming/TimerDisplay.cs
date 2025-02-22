using UnityEngine;
using TMPro;
using Photon.Pun;
using System;

public class TimerDisplay : MonoBehaviourPunCallbacks
{
    public TMP_Text timerText;

    private void Update()
    {
        if (PhotonNetwork.CurrentRoom != null && PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("TimerValue"))
        {
            double timerValue = (double)PhotonNetwork.CurrentRoom.CustomProperties["TimerValue"];
            UpdateTimerText(timerValue);
        }
    }

    private void UpdateTimerText(double timeRemaining)
    {
        if (timerText != null)
        {
            if (timeRemaining > 60)
            {
                int minutes = (int)Math.Floor(timeRemaining / 60);
                double seconds = timeRemaining % 60;
                timerText.text = minutes + ":" + seconds.ToString("00.0");
            }
            else
            {
                timerText.text = timeRemaining.ToString("00.0");
            }
        }
    }
}