using UnityEngine;
using System.Collections;

public class OrbTile : LevelTile
{
	public OrbTile()
	{
		this.allowPlacement = true;
		this.tileObj = Resources.Load("Sphere");
	}
}