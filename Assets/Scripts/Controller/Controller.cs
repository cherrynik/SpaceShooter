using UnityEngine;

public class Controller : MonoBehaviour {


  [SerializeField] private Player  player;
  [SerializeField] private Spawner spawner;

  public Spawner Spawner => spawner;
  public Player  Player  => player;

  private void Start() {
    this.gameObject.AddComponent<State>();
    this.gameObject.AddComponent<Timer>();

    player = GameObject.FindWithTag("Player").GetComponent<Player>();
  }


}
