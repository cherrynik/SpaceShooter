using System;
using UnityEngine;
using Random = System.Random;

public class State : MonoBehaviour {


  // [SerializeField, Range(0, 2)]  private float multiplier = 1.5f;
  [SerializeField, Range(1, 60)] private int timeout = 15;
  private                                int _wave   = 0;
  private                                int _score  = 0;

  private Controller         _gameController;
  private Following          _cameraFollowing;
  private BackgroundMovement _background;
  private Timer              _timer;
  private float              _interval;
  private bool               _isBreak;
  private bool               _isKilled;

  public int  Timeout => timeout;
  public int  Wave    => _wave;
  public int  Score   => _score;
  public bool IsBreak => _isBreak;
  public bool IsKilled {
    get => _isKilled;
    set => _isKilled = value;
  }


  // TODO: working timeout, switching waves, recording scores
  private void Start() {
    _gameController = this.gameObject.GetComponent<Controller>();
    _timer          = this.gameObject.GetComponent<Timer>();

    _cameraFollowing =
      GameObject.FindWithTag("MainCamera").GetComponent<Following>();

    _background = this.gameObject.GetComponent<BackgroundMovement>();

    InitTimer(timeout);
  }

  private void Update() {
    if ((_timer.Timeout == 0) && _isBreak) StartWave();
    else if (_timer.Timeout > 5) SpawnObject(100, 500);
    else if (_isKilled) {
      _score  += new Random().Next(5000, 9000);
      timeout =  timeout < 60 ? timeout + 15 : 60;
      InitTimer(timeout);
    }
  }

  private void InitTimer(int seconds) {
    _isBreak                    = true;
    _timer.Timeout              = seconds;
    _cameraFollowing.IsCentered = true;
    _isKilled                   = false;

    while (_background.Speed < 5)
      _background.Speed += Time.smoothDeltaTime * .5f;
  }

  private void StartWave() {
    _wave++;
    _background.Speed           = 1;
    _isBreak                    = false;
    _cameraFollowing.IsCentered = false;

    while (_background.Speed > 1)
      _background.Speed -= Time.smoothDeltaTime * .5f;

    _gameController.Spawner.SpawnEnemy();
  }

  private void SpawnObject(int minInterval, int maxInterval) {
    if (_interval <= 0) {
      _interval = (float) new Random().Next(minInterval, maxInterval) / 100;
      _gameController.Spawner.SpawnObject();
    } else _interval -= Time.deltaTime;
  }


}
