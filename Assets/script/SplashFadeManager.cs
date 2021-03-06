﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SplashFadeManager : MonoBehaviour {

	List<FadingScript> pages = new List<FadingScript>();

	int current = 0;

	public bool End = false;

	// Use this for initialization
	void Start() {
		pages.Add(GameObject.Find("Splash_01").GetComponent<FadingScript>());
		pages.Add(GameObject.Find("Splash_02").GetComponent<FadingScript>());
		pages.Add(GameObject.Find("Splash_03").GetComponent<FadingScript>());
		pages.Add(GameObject.Find("Splash_04").GetComponent<FadingScript>());
		pages.Add(GameObject.Find("Splash_05").GetComponent<FadingScript>());
		pages.Add(GameObject.Find("Splash_06").GetComponent<FadingScript>());

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

		if (End) {
			Application.LoadLevel("Title");
		}
	}
}
