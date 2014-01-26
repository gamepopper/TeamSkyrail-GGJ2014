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

	public SpriteRenderer surrenderMenu;
	public Sprite surrenderRed;
	public Sprite surrenderBlue;

	public SpriteRenderer optionsMenu;
	public Sprite optionsRed;
	public Sprite optionsBlue;

	public SpriteRenderer helpMenu;
	public Sprite helpRed;
	public Sprite helpBlue;

	public int selection = 0;

	void OnGUI()
	{
		if (GUItype == 0) 
		{
			GUI.skin = guiSkinRed;
			pauseMenu.sprite = pauseRed;
			exitMenu.sprite = exitRed;
			surrenderMenu.sprite = surrenderRed;
			optionsMenu.sprite = optionsRed;
			helpMenu.sprite = helpRed;
		} 
		else 
		{
			GUI.skin = guiSkinBlue;
			pauseMenu.sprite = pauseBlue;
			exitMenu.sprite = exitBlue;
			surrenderMenu.sprite = surrenderBlue;
			optionsMenu.sprite = optionsBlue;
			helpMenu.sprite = helpBlue;
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
<<<<<<< HEAD

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
		else if (exitMenu.enabled) 
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
		else if (surrenderMenu.enabled) 
		{
			Color grey = new Color(0.7f, 0.7f, 0.7f, 1f);
			Color white = new Color(1,1,1,1);
			
			guiLargeText.fontSize = 36;
			
			if (selection == 0)
				guiLargeText.normal.textColor = white;
			else
				guiLargeText.normal.textColor = grey;
			
			GUI.Label(new Rect(Screen.width/2 - 150, Screen.height/2 + 80, 340, 200), "YES", guiLargeText);
			
			if (selection == 1)
				guiLargeText.normal.textColor = white;
			else
				guiLargeText.normal.textColor = grey;
			
			GUI.Label(new Rect(Screen.width/2 + 100, Screen.height/2 + 80, 340, 200), "NO", guiLargeText);
		}
		else if (optionsMenu.enabled)
		{
			//Add gui stuff here!!!
		}
		else if (helpMenu.enabled)
		{
			guiLargeText.fontSize = 24;
			guiLargeText.wordWrap = true;
			GUI.TextArea(new Rect(Screen.width/2 - 180, Screen.height/2 - 70, 360, 430), 
			             "OH MY GOD! PLEASE HELP ME I'M STUCK IN HERE AND I ONLY HAVE 11 HOURS TO FINISH THIS GAME!!!", guiLargeText); 
		}
=======
>>>>>>> parent of 2b43b60... Pause and Exit Menu implemented
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
		else if (surrenderMenu.enabled)
		{
			SurrenderMenuInput();
		}
		else if (optionsMenu.enabled)
		{
			OptionsMenuInput();
		}
		else if (helpMenu.enabled)
		{
			HelpMenuInput();
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

		if (Input.GetKeyDown("return")) 
		{
			exitMenu.enabled = false;

			if (selection == 0)
			{
				Application.LoadLevel("Title");
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
		
		if (Input.GetKeyDown ("return")) 
		{
			switch (selection)
			{
			case 0:
				selection = 0;
				pauseMenu.enabled = false;
				optionsMenu.enabled = true;
				break;
			case 1:
				selection = 0;
				pauseMenu.enabled = false;
				helpMenu.enabled = true;
				break;
			case 2:
				selection = 0;
				pauseMenu.enabled = false;
				surrenderMenu.enabled = true;
				break;
			case 3:
				selection = 0;
				pauseMenu.enabled = false;
				exitMenu.enabled = true;
				break;
			}
		}
	}

	void SurrenderMenuInput()
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
		
		if (Input.GetKeyDown("return")) 
		{
			surrenderMenu.enabled = false;
			
			if (selection == 0)
			{
				Application.LoadLevel("Title");
			}
			else
			{
				pauseMenu.enabled = true;
			}
		}
	}

	void OptionsMenuInput()
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
		
		if (Input.GetKeyDown ("return")) 
		{
			selection = 0;
			optionsMenu.enabled = false;
			pauseMenu.enabled = true;
		}
	}

	void HelpMenuInput()
	{
		if (Input.GetKeyDown ("return")) 
		{
			selection = 0;
			helpMenu.enabled = false;
			pauseMenu.enabled = true;
		}
	}
}