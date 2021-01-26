using System;
using UnityEngine;
using Random = System.Random;

public class Creature : MonoBehaviour {


  [Header("Creature properties:"), SerializeField, Range(1, 100)]
  protected int health;

  [SerializeField, Range(50, 100)] protected int      damage;
  protected                                  int      armor;
  protected                                  Skill[ ] skills;
  private                                    State    _gameState;

  public int Health => health;
  public int Armor  => armor;
  public int Damage => damage;

  // TODO: skills activation
  private void Start() {
    _gameState = GameObject.FindWithTag("GameController").GetComponent<State>();
  }


}
