using UnityEngine;

public class Shooting : MonoBehaviour {


  [Header("Shooting properties:"), SerializeField]
  private GameObject bulletObject;

  [SerializeField, Range(.1f, 2)]  private float     timeout = .5f;
  [SerializeField, Range(1,   50)] private int       speed   = 20;
  [SerializeField]                 private Transform point;
  private                                  float     _timer;

  public int Speed {
    get => speed;
    set => speed = value;
  }

  public float Timer {
    get => _timer;
    set => _timer = value;
  }

  public float Timeout {
    get => timeout;
    set => timeout = value;
  }

  private void Start() => _timer = timeout;

  private void Update() => Shoot();

  private float RefreshTimer(float timer, float val) {
    if (timer < val) return timer + Time.deltaTime;

    return val;
  }

  private void Shoot() {
    bool keyPressed = Input.GetKey(KeyCode.Space);
    _timer = RefreshTimer(_timer, timeout);

    if (!keyPressed ||
        (_timer < timeout)) return;

    Instantiate(bulletObject, point.position, this.transform.rotation);
    _timer = 0;
  }


}
