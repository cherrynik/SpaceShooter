using UnityEngine;

public class Movement : MonoBehaviour {


  [SerializeField, Range(1, 20)] private int speed = 15;

  private Rigidbody2D _body;

  private void Start() { _body = GetComponent<Rigidbody2D>(); }

  private void FixedUpdate() {
    float moveY = Input.GetAxisRaw("Vertical");

    if (moveY == 0) return;

    moveY *= speed * Time.fixedDeltaTime;
    Vector2 position = _body.position;
    Vector2 moveTo   = new Vector2(position.x, position.y + moveY);

    _body.MovePosition(moveTo);
  }


}
