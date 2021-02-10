using UnityEngine;

public class Creature : MonoBehaviour {


  [Header("Creature properties:"), SerializeField, Range(1, 100)]
  protected int health;

  [SerializeField, Range(50, 100)] protected int      damage;
  protected                                  int      armor;
  protected                                  Skill[ ] skills;

  private readonly float _limitX       = 9.5f;
  private readonly float _defaultSpeed = .5f;

  public int Health {
    get => health;
    set => health = value;
  }

  public int Armor  => armor;
  public int Damage => damage;

  // TODO: Skills activation
  // TODO: Init specs
  private void Update() { FirstMove(); }

  private void FirstMove() {
    if (this.gameObject.transform.position.x <= _limitX) return;

    Vector3 transformPosition = this.gameObject.transform.position;

    transformPosition.x = Mathf.Lerp(
      transformPosition.x,
      _limitX,
      _defaultSpeed * Time.deltaTime
    );

    this.gameObject.transform.position = transformPosition;
  }


}
