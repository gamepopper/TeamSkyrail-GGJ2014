using UnityEngine;
using System.Collections.Generic;

public class PauseMenu : MonoBehaviour {

	List<SpriteRenderer> MenuEntries = new List<SpriteRenderer>();
	SpriteRenderer pauseRenderer;
	public bool visible = false;

	// Use this for initialization
	void Start() {
		MenuEntries.Add(GameObject.Find("Pause_End").GetComponent<SpriteRenderer>());
		MenuEntries.Add(GameObject.Find("Pause_Help").GetComponent<SpriteRenderer>());
		MenuEntries.Add(GameObject.Find("Pause_Options").GetComponent<SpriteRenderer>());
		MenuEntries.Add(GameObject.Find("Pause_Resign").GetComponent<SpriteRenderer>());

		pauseRenderer = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update() 
	{
		if (visible) {
				foreach (SpriteRenderer s in MenuEntries) {
					s.enabled = true;
			}
		}
		else
		{
			foreach (SpriteRenderer s in MenuEntries) {
				s.enabled = false;
			}
		}
	}
}
