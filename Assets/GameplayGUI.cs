using UnityEngine;
using System.Collections;

public class GameplayGUI : MonoBehaviour {

	public GUISkin guiSkinRed;
	public GUISkin guiSkinBlue;
	public int GUItype = 0;

	public SpriteRenderer pauseMenu;
	public Sprite pauseRed;
	public Sprite pauseBlue;

	public SpriteRenderer exitMenu;
	public Sprite exitRed;
	public Sprite exitBlue;

	void OnGUI()
	{
		if (GUItype == 0) 
		{
			GUI.skin = guiSkinRed;
			pauseMenu.sprite = pauseRed;
		} 
		else 
		{
			GUI.skin = guiSkinBlue;
			pauseMenu.sprite = pauseBlue;
		}

		if (GUI.Button(new Rect(10, 10, 120, 40), "PAUSE")) {
			//Pause Action
			pauseMenu.enabled = !pauseMenu.enabled;

		}

		if (GUI.Button(new Rect(Screen.width - 130, 10, 120, 40), "END")) {
			//End Action
			exitMenu.enabled = !exitMenu.enabled;
		}

		if (pauseMenu.enabled) 
		{

		}

		GUI.Box(new Rect(5, Screen.height - 190, 200, 180), "Day Number\n\nWorld Opinion\nPublic Opinion");
		GUI.Box(new Rect(Screen.width - 205, Screen.height - 190, 200, 180), "Unit Purchase Options");
		GUI.Box(new Rect(215, Screen.height - 190, Screen.width - 430, 180), "Domination Map Overview");
	}
}
