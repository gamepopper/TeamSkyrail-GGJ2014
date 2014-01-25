using UnityEngine;
using System.Collections;

public class BuildingTile : Tile
{
    public BuildingTile()
    {
        this.allowPlacement = false;
        this.tileObj = Resources.Load("Building");
    }
}