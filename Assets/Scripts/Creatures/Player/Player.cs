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
        Debug.Log("Your lvl is bordered");
        return;
    }

    int op             = toUpgrade ? 1 : -1;
    int operationIndex = new Random().Next(8);

    switch (operationIndex) {
      case 0:
      case 3:
      case 4: {
        if ((!toUpgrade && (health > 100)) || toUpgrade) health += op * 100;

        break;
      }
    }

    switch (operationIndex) {
      case 1:
      case 3:
      case 5: {
        if ((!toUpgrade && (armor > 0)) || toUpgrade) armor += op * 150;

        break;
      }
    }

    switch (operationIndex) {
      case 2:
      case 4:
      case 5: {
        if ((!toUpgrade && (damage > 250)) || toUpgrade)
          shooting.Damage += op * 250;

        break;
      }

      case 6: {
        if ((shooting.Timeout > .19f) &&
            (shooting.Timeout < 2)) shooting.Timeout += -op * .1f;

        break;
      }
    }

    if (operationIndex == 7) Debug.Log(toUpgrade ? "Unluck..." : "Luck!");
    else level += op;
  }


}
