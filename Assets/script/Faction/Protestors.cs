using UnityEngine;
using System.Collections;

public class Protestors : MonoBehaviour {
    public int maxSpawnCount = 10;

    protected int spawnCount;           //KEEPS TRACK OF THE AMOUNT OF UNITS THAT ARE SPAWNED EVERY TURN

    public Protestors() {
        
    }

    public void updateSpawnCount(float publicOpinion) {
        float maxSpawnFloat = maxSpawnCount;
        spawnCount = (int)((maxSpawnFloat / 100) * publicOpinion);
    }
}
