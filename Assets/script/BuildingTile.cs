using UnityEngine;
using System.Collections;

public class BuildingTile : LevelTile
{
	public BuildingTile()
	{
		this.allowPlacement = false;
		this.tileObj = Resources.Load ("Building");
	}
}