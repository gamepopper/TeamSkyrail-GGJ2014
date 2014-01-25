using UnityEngine;
using System.Collections;

public class OrbTile : Tile
{
    public OrbTile()
    {
        this.allowPlacement = true;
        this.tileObj = Resources.Load("Sphere");
    }
}