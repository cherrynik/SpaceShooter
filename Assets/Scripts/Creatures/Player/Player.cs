using System;
using UnityEngine;
using Random = System.Random;

public class Player : Creature {


  [SerializeField, Range(1, 99)] private int      level = 1;
  [SerializeField]               private Shooting shooting;

  public int      Level    => level;
  public Shooting Shooting => shooting;

  // TODO: skills activation

  private void Start() { shooting.Damage = 75; }

  public void Graduate(bool toUpgrade) {
    switch (toUpgrade) {
      case true when level >= 99:
      case false when level == 1:
        return;
    }

    int op             = toUpgrade ? 1 : -1;
    int operationIndex = new Random().Next(8);

    if ((operationIndex == 0) ||
        (operationIndex == 3) ||
        (operationIndex == 4))
      if ((!toUpgrade && (health > 100)) || toUpgrade)
        health += op * 100;

    if ((operationIndex == 1) ||
        (operationIndex == 3) ||
        (operationIndex == 5))
      if ((!toUpgrade && (armor > 0)) || toUpgrade)
        armor += op * 150;

    if ((operationIndex == 2) ||
        (operationIndex == 4) ||
        (operationIndex == 5))
      if ((!toUpgrade && (damage > 250)) || toUpgrade)
        shooting.Damage += op * 250;

    if (operationIndex == 6) {
      if ((shooting.Timeout > .1f) &&
          (shooting.Timeout < 2)) shooting.Timeout += -op * .1f;
    }

    if (operationIndex == 7) Debug.Log(toUpgrade ? "Unluck" : "Luck!");
    else level += op;
  }


}
