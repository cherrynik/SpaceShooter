using System;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMovement : MonoBehaviour {


  [SerializeField, Range(1, 5)] private float      speed = 1;
  [SerializeField]              private GameObject backgroundImage;
  private readonly                      Vector3    _direction   = Vector3.left;
  private                               Vector3    _firstPosition;
  private                               float      _limitPosition;

  public float Speed {
    get => speed;
    set => speed = value;
  }

  private void Start() {
    _firstPosition = backgroundImage.transform.position;

    _limitPosition = _firstPosition.x -
                     (backgroundImage.GetComponent<SpriteRenderer>().size.x *
                      backgroundImage.transform.localScale.x);

    // if (limitPosition == 0) {
    //   limitPosition = isHorizontal
    //     ? backgroundImage.GetComponent<SpriteRenderer>().size.x / 2
    //     : backgroundImage.GetComponent<SpriteRenderer>().size.y / 2;
    // }
  }

  private void FixedUpdate() {
    Vector3 position = backgroundImage.transform.position;

    position =
      position.x <= _limitPosition
        ? _firstPosition
        : position + (_direction * (speed * Time.fixedDeltaTime));

    
    backgroundImage.transform.position = position;
  }


}
