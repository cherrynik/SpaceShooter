using UnityEngine;

public class Controller : MonoBehaviour {


  [SerializeField] private Player   player;
  private                  State    _state;

  private void Start() {
    _state = this.gameObject.AddComponent<State>();
    player = GameObject.FindWithTag("Player").GetComponent<Player>();
  }

  public Player GetPlayer() => player;
}
