using UnityEngine;
using Random = System.Random;

public class FlyingObject : MonoBehaviour {


  [SerializeField, Range(1, 10)] private int    speed    = 3;
  [SerializeField, Range(1, 90)] private int    rotateOn = 15;
  [SerializeField]               private string target   = "Player";
  private                                bool   _isGood;

  private void Start() { _isGood = new Random().Next(0, 2) == 1; }

  private void Update() { Move(); }

  private void OnTriggerEnter2D(Collider2D other) {
    if (!other.gameObject.CompareTag(target)) return;

    // TODO: handler touching with player: up/de- grade
    Destroy(this.gameObject);
  }

  private void Move() {
    Quaternion rotation = this.transform.rotation;

    this.transform.Translate(
      Vector2.left * (speed * Time.deltaTime),
      Space.World
    );

    this.transform.Rotate(
      rotation.x,
      rotation.y,
      (rotation.z + rotateOn) * Time.deltaTime,
      Space.Self
    );
  }


}
