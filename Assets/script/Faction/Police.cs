using UnityEngine;
using System.Collections;

public class Police : Faction {
    protected int money;

    protected int maxPerTurn = 30;
    protected int moneyPerTurn;

    public bool CanSpend(int amount) {
        return amount <= money;
    }

    public void UpdateMoneyPerTurn() {
        this.moneyPerTurn = (int)(maxPerTurn * this.publicOpinion);
    }    
}
