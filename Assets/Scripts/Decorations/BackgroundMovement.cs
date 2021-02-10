using UnityEngine;

public class BackgroundMovement : MonoBehaviour {


  [SerializeField, Range(.1f, 5)] private float      speed = 1;
  [SerializeField]                private GameObject background;
  [SerializeField]                private bool       looped     = true;
  private readonly                        Vector3    _direction = Vector3.left;
  private                                 Vector3    _firstPosition;
  private                                 float      _limitPosition;

  public float Speed {
    get => speed;
    set => speed = value;
  }

  private void Start() {
    _firstPosition = background.transform.position;

    _limitPosition = _firstPosition.x -
                     (background.GetComponent<SpriteRenderer>().size.x *
                      background.transform.localScale.x);
  }

  private void FixedUpdate() {
    Vector3 position = background.transform.position;

    position =
      (position.x <= _limitPosition) && looped
        ? _firstPosition
        : position + (_direction * (speed * Time.fixedDeltaTime));


    background.transform.position = position;
  }


}
