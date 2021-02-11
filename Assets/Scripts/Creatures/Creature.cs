using System;
using UnityEngine;

public class Creature : MonoBehaviour {


  [Header("Creature properties:"), SerializeField]
  protected int health;

  [SerializeField] protected int      damage;
  [SerializeField] protected int      armor;
  protected                  Skill[ ] skills;

  public int Health {
    get => health;
    set => health = value;
  }

  public int Armor {
    get => armor;
    set => armor = value;
  }

  public int Damage => damage;

  // private void Start() => shooting = GetComponent<Shooting>();


}
