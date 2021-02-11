using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bullet : MonoBehaviour {


  [SerializeField, Range(1, 5)] private float    lifeTime = 1f;
  private                               int      _speed   = 20;
  private                               Shooting _shot;
  private                               int      _damage;

  private void Start() {
    _shot   = GameObject.FindWithTag("Player").GetComponent<Shooting>();
    _speed  = _shot.Speed;
    _damage = _shot.Damage;
  }

  private void Update() {
    if (lifeTime <= .0f) Destroy(this.gameObject);
    Move();
  }

  private void Move() {
    this.transform.Translate(
      Vector2.right * (_speed * Time.deltaTime)
    );

    lifeTime -= Time.deltaTime;
  }

  private void OnTriggerEnter2D(Collider2D other) {
    // TODO: Make func DealDamage() in interactable classes for flexibility
    switch (other.gameObject) {
      case { tag: "FlyingObject" }:
        FlyingObject meteor = other.GetComponent<FlyingObject>();
        meteor.LifeTime -= 15;

        break;
      case { tag: "Enemy" }:
        Enemy enemy = other.GetComponent<Enemy>();

        if ((enemy.Armor != 0) &&
            (enemy.Armor <= _damage)) {
          _damage      -= enemy.Armor;
          enemy.Armor  =  0;
          enemy.Health -= _damage;
        } else if (enemy.Armor == 0) {
          enemy.Health -= _damage;
        } else {
          enemy.Armor -= _damage;
        }
        enemy.CheckLife();
        Debug.Log($"Damage dealt: {_damage}");

        break;
      default: return;
    }

    // if (other.gameObject.CompareTag("FlyingObject")) {
    //   metObject = ;
    //   metObject.LifeTime -= 15;
    // } else if (other.gameObject.CompareTag("Enemy")) {
    //   metObject = other.GetComponent<Creature>();
    //   
    //   if (_shot.Damage > metObject.Health) metObject.Health -= _shot.Damage;
    // } else return;

    Destroy(this.gameObject);
  }


}
