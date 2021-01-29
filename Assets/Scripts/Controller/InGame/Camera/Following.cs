using System;
using UnityEngine;

public class Following : MonoBehaviour {


  [SerializeField]                private Transform target;
  [SerializeField]                private float     minY        = 3.5f;
  [SerializeField]                private float     maxY        = 7f;
  [SerializeField, Range(.1f, 2)] private float     smoothTime  = .5f;
  [SerializeField]                private bool      _isCentered = false;
  private                                 float     uncenteredHorizontal;
  private                                 Vector3   _velocity = Vector3.zero;

  public bool IsCentered {
    get => _isCentered;
    set => _isCentered = value;
  }

  private void Start() { uncenteredHorizontal = this.transform.position.x; }

  private void FixedUpdate() {
    Vector3 targetPosition = target.position;

    if (!_isCentered) targetPosition.x = uncenteredHorizontal;
    targetPosition.y = Mathf.Clamp(target.position.y, minY, maxY);
    targetPosition.z = this.transform.position.z;

    this.transform.position = Vector3.SmoothDamp(
      this.transform.position,
      targetPosition,
      ref _velocity,
      smoothTime
    );

    // transform.position = Vector3.SmoothDamp(transform);
  }


}
