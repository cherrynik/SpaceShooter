using UnityEngine;

public class Bullet : MonoBehaviour {


  [SerializeField, Range(1, 5)] private float    _lifeTime = 1f;
  private                               Shooting _shot;
  private                               int      _speed = 20;

  private void Start() {
    _shot  = GameObject.FindWithTag("Player").GetComponent<Shooting>();
    _speed = _shot.Speed;
  }

  private void Update() {
    if (_lifeTime <= .0f) Destroy(this.gameObject);
    Move();

    // TODO: Collision & damage
  }

  private void Move() {
    this.transform.Translate(
      Vector2.right * (_speed * Time.deltaTime)
    );

    _lifeTime -= Time.deltaTime;
  }


}
