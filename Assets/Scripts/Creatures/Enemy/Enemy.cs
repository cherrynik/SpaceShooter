using UnityEngine;
using Random = System.Random;

public class Enemy : Creature {
  
  private readonly float _limitX       = 9.5f;
  private readonly float _defaultSpeed = .5f;
  private          State _gameState;
  // TODO: Skills activation
  // TODO: Init specs
  private void Start() {
    _gameState = GameObject.FindWithTag("GameController").GetComponent<State>();
    InitLife();
  }

  private void Update() {
    FirstMove();
  }

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

  private void InitLife() {
    int gameWave = _gameState.Wave;
    armor = 6000;
    health = 2000;
  }

  public void CheckLife() {
    Debug.Log($"Armor: {armor} Health: {health}");

    if (health > 0) return;

    _gameState.IsKilled = true;
    Destroy(this.gameObject);
  }


}
