using UnityEngine;
using System.Collections;

public class GameplayGUI : MonoBehaviour {

	public GUISkin guiSkinRed;
	public GUISkin guiSkinBlue;
	public GUIStyle guiLargeText;
	public int GUItype = 0;

	public bool pauseMenuenabled = false;
	public SpriteRenderer pauseMenu;
	public Sprite pauseRed;
	public Sprite pauseBlue;

	public bool exitMenuenabled = false;
	public SpriteRenderer exitMenu;
	public Sprite exitRed;
	public Sprite exitBlue;

	public bool surrenderMenuenabled = false;
	public SpriteRenderer surrenderMenu;
	public Sprite surrenderRed;
	public Sprite surrenderBlue;

	public bool optionsMenuenabled = false;
	public SpriteRenderer optionsMenu;
	public Sprite optionsRed;
	public Sprite optionsBlue;

	public bool helpMenuenabled = false;
	public SpriteRenderer helpMenu;
	public Sprite helpRed;
	public Sprite helpBlue;

	public int selection = 0;

	private float originalWidth = 1920.0f; // define here the original resolution
	private float originalHeight = 1080.0f; // you used to create the GUI contents
	private Vector3 scale;

	void Start()
	{
		GUItype = GameObject.Find("DecisionObject").
			GetComponent<PersistantScripts>().choice;
	}

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
			pauseMenuenabled = !pauseMenuenabled;
			exitMenuenabled = false;
		}

		if (GUI.Button(new Rect(Screen.width - 130, 10, 120, 40), "END")) 
		{
			//End Action
			exitMenuenabled = !exitMenuenabled;
			pauseMenuenabled = false;
		}

		GUI.Box(new Rect(5, Screen.height - 190, 200, 180), ".\nWorld Opinion\n\n\n\nPublic Opinion");

		float worldOpvalue = GameObject.Find("city1").GetComponent<Map>().getWorldOpinion();

		string worldOpText = "";

		if (worldOpvalue < 0.2f)
		{
			worldOpText = "Everything is A-OK!";
		}
		else if (worldOpvalue < 0.4f)
		{
			worldOpText = "There's a storm coming.";
		}
		else if (worldOpvalue < 0.6f)
		{
			worldOpText = "Could be worse.";
		}
		else if (worldOpvalue < 0.8f)
		{
			worldOpText = "Something must be done!";
		}
		else if (worldOpvalue < 1f)
		{
			worldOpText = "OH DEAR GOD THE HUMANITY!";
		}
		else
		{

		}

		GUI.Label(new Rect(30, Screen.height - 150, 200, 150), worldOpText);

		GUI.Box(new Rect(Screen.width - 205, Screen.height - 190, 200, 180), ".\nUnit Purchase\nOptions");
		GUI.Box(new Rect(215, Screen.height - 190, Screen.width - 430, 180), ".\nDomination Map Overview");

		if (pauseMenuenabled) 
		{
			GUI.DrawTexture(new Rect(Screen.width/2 - 120, Screen.height/2 - 120, 349/1.5f, 437/1.5f), pauseMenu.sprite.texture);

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
		if (exitMenuenabled) 
		{
			GUI.DrawTexture(new Rect(Screen.width/2 - 205, Screen.height/2 - 150, 611/1.5f, 438/1.5f), exitMenu.sprite.texture);

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
		if (surrenderMenuenabled) 
		{
			GUI.DrawTexture(new Rect(Screen.width/2 - 205, Screen.height/2 - 150, 611/1.5f, 438/1.5f), surrenderMenu.sprite.texture);
			Color grey = new Color(0.7f, 0.7f, 0.7f, 1f);
			Color white = new Color(1,1,1,1);
			
			guiLargeText.fontSize = 36;
			
			if (selection == 0)
				guiLargeText.normal.textColor = white;
			else
				guiLargeText.normal.textColor = grey;
			
			GUI.Label(new Rect(Screen.width/2 - 170, Screen.height/2 + 80, 340, 200), "ACCEPT", guiLargeText);
			
			if (selection == 1)
				guiLargeText.normal.textColor = white;
			else
				guiLargeText.normal.textColor = grey;
			
			GUI.Label(new Rect(Screen.width/2 + 10, Screen.height/2 + 80, 340, 200), "DECLINE", guiLargeText);
		}
		if (optionsMenuenabled)
		{
			GUI.DrawTexture(new Rect(Screen.width/2 - 200, Screen.height/2 - 150, 609/1.5f, 437/1.5f), optionsMenu.sprite.texture);
			//Add gui stuff here!!!
		}
		if (helpMenuenabled)
		{
			GUI.DrawTexture(new Rect(Screen.width/2 - 210, Screen.height/2 - 150, 611/1.5f, 438/1.5f), helpMenu.sprite.texture);
			guiLargeText.fontSize = 24;
			guiLargeText.wordWrap = true;
			GUI.TextArea(new Rect(Screen.width/2 - 180, Screen.height/2 - 70, 360, 430), 
			             "OH MY GOD! PLEASE HELP ME I'M STUCK IN HERE AND I ONLY HAVE 6 HOURS TO FINISH THIS GAME!!!", guiLargeText); 
		}
	}

	void Update()
	{
		if (exitMenuenabled) 
		{
			ExitMenuInput();
		} 
		else if (pauseMenuenabled) 
		{
			PauseMenuInput();
		}
		else if (surrenderMenuenabled)
		{
			SurrenderMenuInput();
		}
		else if (optionsMenuenabled)
		{
			OptionsMenuInput();
		}
		else if (helpMenuenabled)
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
			exitMenuenabled = false;

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
				pauseMenuenabled = false;
				optionsMenuenabled = true;
				break;
			case 1:
				selection = 0;
				pauseMenuenabled = false;
				helpMenuenabled = true;
				break;
			case 2:
				selection = 0;
				pauseMenuenabled = false;
				surrenderMenuenabled = true;
				break;
			case 3:
				selection = 0;
				pauseMenuenabled = false;
				exitMenuenabled = true;
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
			surrenderMenuenabled = false;
			
			if (selection == 0)
			{
				Application.LoadLevel("Title");
			}
			else
			{
				pauseMenuenabled = true;
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
			optionsMenuenabled = false;
			pauseMenuenabled = true;
		}
	}

	void HelpMenuInput()
	{
		if (Input.GetKeyDown ("return")) 
		{
			selection = 0;
			helpMenuenabled = false;
			pauseMenuenabled = true;
		}
	}
}