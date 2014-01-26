using UnityEngine;
using System.Collections;

public class MenuSelect : MonoBehaviour {
	public int Selection = 0;

	public GameObject FactSelectBlue;
	public GameObject FactSelectRed;

	Vector3 prevMousePosition = new Vector3();

	bool useMouse = false;

	// Use this for initialization
	void Start() {
		Color blueColour = FactSelectBlue.GetComponent<SpriteRenderer>().color;
		Color redColour = FactSelectRed.GetComponent<SpriteRenderer>().color;

		blueColour.a = 0;
		redColour.a = 0;

		FactSelectBlue.GetComponent<SpriteRenderer>().color = blueColour;
		FactSelectRed.GetComponent<SpriteRenderer>().color = redColour;
	}
	
	// Update is called once per frame
	void Update() {
		SelectionUpdate();

		if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("return")) 
		{
			GameObject.Find("DecisionObject").
				GetComponent<PersistantScripts>().choice = Selection - 1;
			Application.LoadLevel("Prologue");
		}
	}

	private void SelectionUpdate()
	{
		useMouse = !(prevMousePosition == Input.mousePosition);
		
		Color blueColour = FactSelectBlue.GetComponent<SpriteRenderer>().color;
		Color redColour = FactSelectRed.GetComponent<SpriteRenderer>().color;
		
		if (Input.GetKey("left") || (useMouse && Input.mousePosition.x < Screen.width/2)) 
		{
			//Select Regime
			Selection = 1;
		}
		if (Input.GetKey("right") || (useMouse && Input.mousePosition.x > Screen.width/2)) 
		{
			//Select Uprising
			Selection = 2;
		}
		
		if (Selection == 1) 
		{
			blueColour.a -= Time.deltaTime * 5;
			redColour.a += Time.deltaTime * 5;
			
			if (redColour.a > 1)
				redColour.a = 1;
			if (blueColour.a < 0)
				blueColour.a = 0;
		} 
		else if (Selection == 2) 
		{
			blueColour.a += Time.deltaTime * 5;
			redColour.a -= Time.deltaTime * 5;
			
			if (blueColour.a > 1)
				blueColour.a = 1;
			if (redColour.a < 0)
				redColour.a = 0;
		}

		FactSelectBlue.GetComponent<SpriteRenderer>().color = blueColour;
		FactSelectRed.GetComponent<SpriteRenderer>().color = redColour;
		
		prevMousePosition = Input.mousePosition;
	}
}