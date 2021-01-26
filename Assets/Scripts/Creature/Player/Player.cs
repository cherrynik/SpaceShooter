using UnityEngine;

public class Player : Creature {


  [SerializeField, Range(1, 99)] private int level = 1;

  public int Level => level;

  // TODO: skills activation


}
