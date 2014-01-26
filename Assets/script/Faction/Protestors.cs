using UnityEngine;
using System.Collections;

public class Protestors : Faction {
    public int maxSpawnCount = 10;

    protected int spawnCount;           //KEEPS TRACK OF THE AMOUNT OF UNITS THAT ARE SPAWNED EVERY TURN

    public Protestors() {
        
    }

    public void updateSpawnCount() {
        float maxSpawnFloat = maxSpawnCount;
        spawnCount = (int)((maxSpawnFloat * this.publicOpinion));
    }
}
