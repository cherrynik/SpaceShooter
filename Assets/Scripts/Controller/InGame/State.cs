using System;
using System.Collections;
using UnityEngine;

public class State : MonoBehaviour {


  [SerializeField, Range(0, 2)]  private float multiplier = 1.5f;
  [SerializeField, Range(1, 60)] private int   timeout    = 80;
  private                                Timer timer;
  private                                int   _wave    = 0;
  private                                int   _score   = 0;
  private                                bool  _isBreak = true;

  public int  Timeout => timeout;
  public int  Wave    => _wave;
  public int  Score   => _score;
  public bool IsBreak => _isBreak;

  // TODO: working timeout, switching waves, recording scores
  private void Start() {
    timer         = this.gameObject.GetComponent<Timer>();
    timer.Timeout = timeout;
  }


}
