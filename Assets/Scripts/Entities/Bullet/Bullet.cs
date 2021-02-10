using System;
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
    if (other.gameObject.CompareTag("FlyingObject"))
      other.GetComponent<FlyingObject>().LifeTime -= 15;
    else if (other.gameObject.CompareTag("Enemy"))
      other.GetComponent<Creature>().Health -= _shot.Damage;
    else return;

    Destroy(this.gameObject);
  }


}
