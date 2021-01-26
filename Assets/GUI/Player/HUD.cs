using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Math;

public class HUD : MonoBehaviour {


  [SerializeField] private Text       health;
  [SerializeField] private Text       timeout;
  [SerializeField] private Controller gameController;
  private                  Player     _player;
  private                  Shooting   _timer;

  private void Start() {
    gameController = GameObject.FindWithTag("GameController").
      GetComponent<Controller>();

    _player = gameController.GetPlayer();
    _timer  = _player.GetComponent<Shooting>();
  }

  private void Update() {
    health.text  = $"HP {_player.Health}";
    
    // float text                  = (float) Round(_timer.Timer, 1);
    // if (text != .0f) timeout.text = $"Timeout {text}";
    // else timeout.text             = "Timeout 0,0";
  }


}
