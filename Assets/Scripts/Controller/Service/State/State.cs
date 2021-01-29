using System;
using UnityEngine;
using Random = System.Random;

public class State : MonoBehaviour {


  // [SerializeField, Range(0, 2)]  private float multiplier = 1.5f;
  [SerializeField, Range(1, 60)] private int timeout = 15;
  private                                int _wave   = 0;
  private                                int _score  = 0;

  private Controller _gameController;
  private Following  _cameraFollowing;
  private Timer      _timer;
  private float      _interval;
  private bool       _isBreak;

  public int Timeout => timeout;
  public int Wave    => _wave;
  public int Score   => _score;

  // TODO: working timeout, switching waves, recording scores
  private void Start() {
    _gameController = this.gameObject.GetComponent<Controller>();
    _timer          = this.gameObject.GetComponent<Timer>();

    _cameraFollowing =
      GameObject.FindWithTag("MainCamera").GetComponent<Following>();

    InitTimer(timeout);
  }

  private void Update() {
    if ((_timer.Timeout == 0) &&
        _isBreak) { StartWave(); } else if (_timer.Timeout > 5) {
      SpawnObject(100, 500);
    }
  }

  private void InitTimer(int seconds) {
    _isBreak                    = true;
    _timer.Timeout              = seconds;
    _cameraFollowing.IsCentered = true;
  }

  private void StartWave() {
    _wave++;
    _isBreak                    = false;
    _cameraFollowing.IsCentered = false;

    // _gameController.Spawner.SpawnBoss();
  }

  private void SpawnObject(int minInterval, int maxInterval) {
    if (_interval <= 0) {
      _interval = (float) new Random().Next(minInterval, maxInterval) / 100;
      _gameController.Spawner.SpawnObject();
    } else _interval -= Time.deltaTime;
  }


}
