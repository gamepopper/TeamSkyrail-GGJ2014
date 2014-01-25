using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SplashFadeManager : MonoBehaviour {

	List<FadingScript> pages = new List<FadingScript>();

	int current = 0;

	public bool End = false;

	// Use this for initialization
	void Start () {
		pages.Add(GameObject.Find("Splash_01").GetComponent<FadingScript>());
		pages.Add(GameObject.Find("Splash_02").GetComponent<FadingScript>());
		pages.Add(GameObject.Find("Splash_03").GetComponent<FadingScript>());
		pages.Add(GameObject.Find("Splash_04").GetComponent<FadingScript>());
		pages.Add(GameObject.Find("Splash_05").GetComponent<FadingScript>());
		pages.Add(GameObject.Find("Splash_06").GetComponent<FadingScript>());

		pages[current].StartFade = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (current + 1 < pages.Count) {
			if (pages[current].IsFadeOutComplete())
			{
				current++;
				pages[current].StartFade = true;
			}
		}
		else
		{
			End = true;
		}
	}
}
