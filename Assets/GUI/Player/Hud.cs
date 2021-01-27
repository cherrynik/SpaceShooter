using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Math;

public class Hud : MonoBehaviour {


  [SerializeField] private Text       health;
  [SerializeField] private Text       timer;
  [SerializeField] private Text       timeout;
  [SerializeField] private Controller gameController;
  private                  Player     _player;
  private                  Timer      _timer;

  private void Start() {
    gameController = GameObject.FindWithTag("GameController").
      GetComponent<Controller>();

    _player = gameController.GetPlayer();
    _timer  = gameController.GetComponent<Timer>();
  }

  private void Update() {
    health.text = $"HP {_player.Health}";
    timer.text  = _timer.GetTimeFormatted();
    
    // float text                  = (float) Round(_player.Tim, 1);
    // if (text != .0f) timeout.text = $"Timeout {text}";
    // else timeout.text             = "Timeout 0,0";
  }


}
