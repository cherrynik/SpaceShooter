using System;
using UnityEngine;
using Random = System.Random;

public class FlyingObject : MonoBehaviour {


  [SerializeField] private string target    = "Player";
  [SerializeField] private float  lifeTime  = 30f;
  private                  int    _speed    = 3;
  private                  int    _rotateOn = 20;
  private                  bool   _isGood;

  public float LifeTime {
    get => lifeTime;
    set => lifeTime = value;
  }

  private void Start() {
    GenerateSpeed();
    GenerateQuality();
  }

  private void Update() {
    Move();
    RunLifeTime();
  }

  private void OnTriggerEnter2D(Collider2D other) {
    if (!other.gameObject.CompareTag(target)) return;

    Player player = other.gameObject.GetComponent<Player>();
    player.Graduate(_isGood);
    Destroy(this.gameObject);
  }

  private void GenerateSpeed() {
    _speed    = new Random().Next(1,  7);
    _rotateOn = new Random().Next(10, 26);

    // size depending from speed;
    this.gameObject.transform.localScale = _speed switch {
      1 => new Vector3(3,    3,    3),
      2 => new Vector3(2.5f, 2.5f, 2.5f),
      3 => new Vector3(2,    2,    2),
      4 => new Vector3(1.5f, 1.5f, 1.5f),
      5 => new Vector3(1,    1,    1),
      6 => new Vector3(.5f,  .5f,  .5f),
    };
  }

  private void GenerateQuality() {
    _isGood = new Random().Next(0, 2) == 1;

    // Example behaviour of sprite from object's quality
    this.gameObject.GetComponent<SpriteRenderer>().color =
      _isGood
        ? new Color(.5f, 1f,  .5f)
        : new Color(1f,  .5f, .5f);
  }

  private void Move() {
    Quaternion rotation = this.transform.rotation;

    this.transform.Translate(
      Vector2.left * (_speed * Time.deltaTime),
      Space.World
    );

    this.transform.Rotate(
      rotation.x,
      rotation.y,
      (rotation.z + _rotateOn) * Time.deltaTime,
      Space.Self
    );
  }

  private void RunLifeTime() {
    lifeTime -= Time.deltaTime;
    if (lifeTime <= 0) Destroy(this.gameObject);
  }


}
