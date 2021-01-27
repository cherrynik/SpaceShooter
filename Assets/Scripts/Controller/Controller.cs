using System;
using UnityEngine;

public class Controller : MonoBehaviour {


  [SerializeField] private Player player;

  private void Start() {
    this.gameObject.AddComponent<State>();
    this.gameObject.AddComponent<Timer>();
    this.gameObject.AddComponent<WaveBreak>();

    player = GameObject.FindWithTag("Player").GetComponent<Player>();
  }

  public Player GetPlayer() => player;


}
