using UnityEngine;
using System.Collections.Generic;
using System;

public class GameOverFadeManager : MonoBehaviour {

	List<FadingScript> pages = new List<FadingScript>();
	public int choice = 0;
	int current = 0;
	public GUISkin guiSkin;
	
	public bool End = false;
	
	// Use this for initialization
	void Start() {
		//Find winner
		try
		{
			choice = GameObject.Find("DecisionObject").
				GetComponent<PersistantScripts>().choice;
		}
		catch (NullReferenceException e)
		{
			choice = 0;
		}

		if (choice == 0) 
		{
			pages.Add(GameObject.Find("Defeat_Blue").GetComponent<FadingScript>());
			pages.Add(GameObject.Find("Victory_Red").GetComponent<FadingScript>());
		}
		else
		{
			pages.Add(GameObject.Find("Defeat_Red").GetComponent<FadingScript>());
			pages.Add(GameObject.Find("Victory_Blue").GetComponent<FadingScript>());
		}
		
		pages[current].StartFade = true;
	}
	
	// Update is called once per frame
	void Update() {
		if (current < pages.Count) {
			try
			{
				if (pages[current].IsFadeOutStart())
				{
					current++;
					pages[current].StartFade = true;
				}
			}
			catch (ArgumentOutOfRangeException aore)
			{
				End = true;
			}
		}
		else
		{
			End = true;
		}
		
		if (Input.GetKeyDown("return"))
		{
			Application.LoadLevel("Title");
		}
	}
}
