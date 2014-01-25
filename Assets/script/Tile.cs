using UnityEngine;
using System.Collections;

public class Tile
{
    protected bool allowPlacement;
    protected Object tileObj;

    public Tile()
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
