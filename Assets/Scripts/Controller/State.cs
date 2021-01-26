using UnityEngine;

public class State : MonoBehaviour {


  [SerializeField] private int timeout = 30;
  private                  int _wave   = 0;
  private                  int _score  = 0;

  // TODO: working timeout, switching waves, recording scores
  public int Wave => _wave;


}
