using UnityEngine;
using System.Collections;

public class Tile {
	bool allowPlacement = false;
	// Use this for initialization
	void Start () {
	
	}

	public bool canPlaceHere(GameObject theObject) {
		return allowPlacement;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
