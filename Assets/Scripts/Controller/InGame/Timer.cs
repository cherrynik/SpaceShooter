using System;
using UnityEngine;

public class Timer : MonoBehaviour {


  private float _timeout;

  public float Timeout {
    get => (int) Math.Round(_timeout);
    set => _timeout = value;
  }

  private void Update() {
    if (_timeout > 0) _timeout -= Time.deltaTime;
    else if (_timeout == 0) return;
    else _timeout = 0;

    GetTimeFormatted();
  }

  public string GetTimeFormatted() {
    int total = (int) Math.Round(_timeout);

    int minutes = (int) (_timeout > 60 ? Math.Round((float) total / 60) : 0);
    int seconds = total % 60;

    return $"{FormatTime(minutes)}:{FormatTime(seconds)}";
  }

  private string FormatTime(int time) => time <= 9 ? $"0{time}" : $"{time}";


}
