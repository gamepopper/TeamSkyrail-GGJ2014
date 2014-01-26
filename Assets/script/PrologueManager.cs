using UnityEngine;
using System;
using System.Collections.Generic;

public class PrologueManager : MonoBehaviour {

	List<FadingScript> pages = new List<FadingScript>();
	public int choice = 0;
	int current = 0;
	public GUISkin guiSkin;
	
	public bool End = false;

	void OnGUI()
	{
		if (End) 
		{
			GUI.skin = guiSkin;
			GUI.Label(new Rect(20, 10, 300, 100), "Press Return to Start");
		}
		GUI.skin = null;
	}

	// Use this for initialization
	void Start() {
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
			pages.Add(GameObject.Find("Prologue_BlankRed").GetComponent<FadingScript>());
			pages.Add(GameObject.Find("Prologue_Red01").GetComponent<FadingScript>());
		}
		else
		{
			pages.Add(GameObject.Find("Prologue_BlankBlue").GetComponent<FadingScript>());
			pages.Add(GameObject.Find("Prologue_Blue01").GetComponent<FadingScript>());
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
			Application.LoadLevel("City");
		}
	}
}
