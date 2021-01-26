using UnityEngine;

public class Shooting : MonoBehaviour {


  [Header("Shooting properties:"), SerializeField]
  private GameObject bulletObject;

  [SerializeField, Range(.1f, 1f)] private float     timeout = .5f;
  [SerializeField, Range(20,  50)] private int       speed   = 20;
  [SerializeField]                 private Transform point;
  private                                  float     _timer;

  public int   Speed => speed;
  public float Timer => _timer;

  private void Start() { _timer = timeout; }

  private void Update() {
    bool keyPressed = Input.GetKey(KeyCode.Space);
    _timer = RefreshTimer(_timer, timeout);

    if (!keyPressed ||
        (_timer < timeout)) return;

    Instantiate(bulletObject, point.position, this.transform.rotation);
    _timer = 0;
  }

  public float RefreshTimer(float timer, float val) {
    if (timer < val) return timer += Time.deltaTime;

    return val;
  }


}
