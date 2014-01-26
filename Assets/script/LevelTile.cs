using UnityEngine;
using System.Collections;

public class LevelTile
{
	protected bool allowPlacement;
	protected Object tileObj;
	
	public LevelTile()
	{
		this.allowPlacement = false;
	}
	
	public bool canPlaceHere(GameObject theObject)
	{
		return allowPlacement;
	}
	
	public Object getObj()
	{
		return tileObj;
	}
}
