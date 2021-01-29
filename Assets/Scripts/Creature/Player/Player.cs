using System;
using UnityEngine;

public class Player : Creature {


  [SerializeField, Range(1, 99)] private int      level = 1;
  private                                Shooting _shooting;

  public Shooting Shooting => _shooting;
  public int      Level    => level;

  // TODO: skills activation
  private void Start() {
    _shooting = GetComponent<Shooting>();
  }


}
