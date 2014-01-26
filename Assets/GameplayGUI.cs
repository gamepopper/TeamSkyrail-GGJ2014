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

	public int selection = 0;

	void OnGUI()
	{
		if (GUItype == 0) 
		{
			GUI.skin = guiSkinRed;
			pauseMenu.sprite = pauseRed;
			exitMenu.sprite = exitRed;
		} 
		else 
		{
			GUI.skin = guiSkinBlue;
			pauseMenu.sprite = pauseBlue;
			exitMenu.sprite = exitBlue;
		}

		if (GUI.Button(new Rect(10, 10, 120, 40), "PAUSE")) 
		{
			//Pause Action
			pauseMenu.enabled = !pauseMenu.enabled;
			exitMenu.enabled = false;

		}

		if (GUI.Button(new Rect(Screen.width - 130, 10, 120, 40), "END")) 
		{
			//End Action
			exitMenu.enabled = !exitMenu.enabled;
			pauseMenu.enabled = false;
		}

		GUI.Box(new Rect(5, Screen.height - 190, 200, 180), "Day Number\n\nWorld Opinion\nPublic Opinion");
		GUI.Box(new Rect(Screen.width - 205, Screen.height - 190, 200, 180), "Unit Purchase Options");
		GUI.Box(new Rect(215, Screen.height - 190, Screen.width - 430, 180), "Domination Map Overview");
	}

	void Update()
	{
		if (exitMenu.enabled) 
		{
			ExitMenuInput();
		} 
		else if (pauseMenu.enabled) 
		{
			PauseMenuInput();
		}
		else 
		{
			selection = 0;
		}
	}

	void ExitMenuInput()
	{
		if (Input.GetKeyDown ("up")) 
		{
			selection--;

			if (selection < 0) 
			{
				selection += 2;
			}
		}

		if (Input.GetKeyDown("down")) 
		{
			selection = (selection + 1) % 2;
		}
	}

	void PauseMenuInput()
	{
		if (Input.GetKeyDown ("up")) 
		{
			selection--;
			
			if (selection < 0) 
			{
				selection += 4;
			}
		}
		
		if (Input.GetKeyDown("down")) 
		{
			selection = (selection + 1) % 4;
		}
	}
}