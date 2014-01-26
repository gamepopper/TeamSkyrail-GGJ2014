using UnityEngine;
using System.Collections;

public class GameplayGUI : MonoBehaviour {

	public GUISkin guiSkinRed;
	public GUISkin guiSkinBlue;
	public GUIStyle guiLargeText;
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

		if (pauseMenu.enabled) 
		{
			Color grey = new Color(0.7f, 0.7f, 0.7f, 1f);
			Color white = new Color(1,1,1,1);

			guiLargeText.fontSize = 36;

			if (selection == 0)
				guiLargeText.normal.textColor = white;
			else
				guiLargeText.normal.textColor = grey;

			GUI.Label(new Rect(Screen.width/2 - 90, Screen.height/2 - 30, 340, 200), "OPTIONS", guiLargeText);

			if (selection == 1)
				guiLargeText.normal.textColor = white;
			else
				guiLargeText.normal.textColor = grey;

			GUI.Label(new Rect(Screen.width/2 - 90, Screen.height/2 + 10, 340, 200), "HELP", guiLargeText);

			if (selection == 2)
				guiLargeText.normal.textColor = white;
			else
				guiLargeText.normal.textColor = grey;

			GUI.Label(new Rect(Screen.width/2 - 90, Screen.height/2 + 50, 340, 200), "RESIGN", guiLargeText);

			if (selection == 3)
				guiLargeText.normal.textColor = white;
			else
				guiLargeText.normal.textColor = grey;

			GUI.Label(new Rect(Screen.width/2 - 90, Screen.height/2 + 90, 340, 200), "END", guiLargeText);
		}

		if (exitMenu.enabled) 
		{
			Color grey = new Color(0.7f, 0.7f, 0.7f, 1f);
			Color white = new Color(1,1,1,1);
			
			guiLargeText.fontSize = 36;

			if (selection == 0)
				guiLargeText.normal.textColor = white;
			else
				guiLargeText.normal.textColor = grey;
			
			GUI.Label(new Rect(Screen.width/2 - 170, Screen.height/2 + 80, 340, 200), "CONFIRM", guiLargeText);
			
			if (selection == 1)
				guiLargeText.normal.textColor = white;
			else
				guiLargeText.normal.textColor = grey;
			
			GUI.Label(new Rect(Screen.width/2 + 20, Screen.height/2 + 80, 340, 200), "RETURN", guiLargeText);
		}
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
		if (Input.GetKeyDown ("left")) 
		{
			selection--;

			if (selection < 0) 
			{
				selection = 0;
			}
		}

		if (Input.GetKeyDown("right")) 
		{
			selection++;

			if (selection > 1)
			{
				selection = 1;
			}
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