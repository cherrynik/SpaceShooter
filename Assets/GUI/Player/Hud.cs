using System;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour {


  [SerializeField] private Text       health;
  [SerializeField] private Text       timer;
  [SerializeField] private Text       timeout;
  [SerializeField] private Controller gameController;
  private                  Player     _player;
  private                  Timer      _timer;

  private void Start() {
    if (!gameController)
      gameController = GameObject.FindWithTag("GameController").
        GetComponent<Controller>();

    _player = gameController.Player;
    _timer  = gameController.GetComponent<Timer>();
  }

  private void Update() {
    health.text = $"HP {_player.Health}";
    timer.text  = _timer.GetTimeFormatted();

    float text                  = (float) Math.Round(_player.Shooting.Timer, 1);
    timeout.text = text != .0f ? $"Timeout {text}" : "Timeout 0,0";
  }


}
