using System;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour {


  [SerializeField] private Text       health;
  [SerializeField] private Text       armor;
  [SerializeField] private Text       level;
  [SerializeField] private Text       timer;
  [SerializeField] private Text       timeout;
  [SerializeField] private Text       score;
  [SerializeField] private Text       wave;
  [SerializeField] private Controller gameController;
  private                  Player     _player;
  private                  Timer      _timer;
  private                  State      _gameState;

  private void Start() {
    if (!gameController) {
      gameController = GameObject.FindWithTag("GameController").
        GetComponent<Controller>();
    }

    _player    = gameController.Player;
    _timer     = gameController.GetComponent<Timer>();
    _gameState = gameController.GetComponent<State>();
  }

  private void Update() {
    health.text = $"HP {_player.Health}";
    timer.text  = _timer.GetTimeFormatted();
    armor.text  = $"Armor {_player.Armor}";
    level.text  = $"Level {_player.Level}";

    float text = (float) Math.Round(_player.Shooting.Timer, 1);
    timeout.text = text != .0f ? $"Timeout {text}" : "Timeout 0,0";
    score.text   = $"Score: {_gameState.Score}";

    wave.text = _gameState.IsBreak
      ? $"Wave {_gameState.Wave + 1}"
      : $"Wave {_gameState.Wave}";
  }


}
