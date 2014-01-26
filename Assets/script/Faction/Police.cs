using UnityEngine;
using System.Collections;

public class Police : Faction {
    protected int money;

    protected int moneyPerTurn;

    public bool CanSpend(int amount) {
        return amount <= money;
    }
}
