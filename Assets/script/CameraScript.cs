using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
	Vector3 overCamPos = new Vector3(4.606995f, 0, -11.62317f);
	float closeZ = -3;
	Vector3 closeCamPos;
	Vector3 moveCamPos;
	float transitionTime = 0.3f;
	float timeCount = 0;
	float fraction = 0;
	const int STATE_UNZOOMED = 0;
	const int STATE_ZOOMING = 1;
	const int STATE_ZOOMED = 2;
	const int STATE_UNZOOMING = 3;
	int transitionState = STATE_UNZOOMED;

	public Map map;

	bool dragging = false;
	float dragSpeed = 0.001f;

	Vector2 dragPos;
	Vector2 targetCamPos;
	
	// Use this for initialization
	void Start ()
	{
		closeCamPos = new Vector3 (4.606995f, 0, closeZ);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (transitionState > 3)
		{
			transitionState = STATE_UNZOOMED;
		}

		if (Input.GetKeyDown(KeyCode.Space) && (transitionState % 2 != 1))	// Not true if zooming/unzooming.
		{
			transitionState++;

			if (transitionState == STATE_UNZOOMING)
			{
				closeCamPos = moveCamPos;
			}
		}

		if (transitionState == STATE_UNZOOMING)
		{
			interpCamera (moveCamPos, overCamPos);
		}

		if (transitionState == STATE_ZOOMING)
		{
			interpCamera (overCamPos, closeCamPos);
		}
		else
		{
			if (Input.GetKeyDown (KeyCode.Mouse0))	// Called when not zooming, otherwise closePos could be changed while moving towards it.
			{
				map.SelectClicked ();	// Calling here may mean this gets called twice for one click, but not calling it might mean setting closeCamPos to the selected tile position before the clicked tile is selected.
				if (map.selectedTile.x != -1)
				{
					Vector2 tilePos = map.GetPositionFromTile (map.selectedTile.x, map.selectedTile.y);
					
					closeCamPos = new Vector3((map.GetLeft() + tilePos.x), (map.GetTop() - tilePos.y), closeZ);
				}
			}
		}

		if (transitionState == STATE_ZOOMED)
		{
			if (Input.GetKeyDown(KeyCode.Mouse1))
			{
				dragPos = Input.mousePosition;
			}

			if (Input.GetKey(KeyCode.Mouse1))
			{
				dragging = true;
			}

			if (dragging)
			{
				targetCamPos = new Vector2((Input.mousePosition.x - dragPos.x)*dragSpeed, (Input.mousePosition.y - dragPos.y)*dragSpeed);

				// Ensures camera stays within map boundaries.
				if ((targetCamPos.x + camera.transform.position.x) < map.GetLeft())
					targetCamPos.x = map.GetLeft() - camera.transform.position.x;
				if ((targetCamPos.x + camera.transform.position.x) > map.GetRight())
					targetCamPos.x = map.GetRight() - camera.transform.position.x;
				if ((targetCamPos.y + camera.transform.position.y) > map.GetTop())
					targetCamPos.y = map.GetTop() - camera.transform.position.y;
				if ((targetCamPos.y + camera.transform.position.y) < map.GetBottom())
					targetCamPos.y = map.GetBottom() - camera.transform.position.y;

				camera.transform.Translate(targetCamPos);

				moveCamPos = camera.transform.position;

				dragging = false;	// Need this so that if you unzoom while dragging, you won't be dragging without the mouse button down when zoomed back in.
									// Will be set to true every frame that the button is held down before the program reaches the section of code that deals with draggin behaviour.
			}
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.Mouse1))		// Mouse dragging needs to always be checked for to avoid cases where the right mouse button is down but a new starting drag position hasn't been set.
			{											// Also is a better player experience, where they decide how they want to move (and clicking) before movement is enabled.
				dragPos = Input.mousePosition;
				dragging = true;
			}
			
			if (Input.GetKeyUp(KeyCode.Mouse1))
			{
				dragging = false;
			}
		}
	}

	void interpCamera(Vector3 start, Vector3 end)
	{
		if (timeCount < transitionTime)
		{
			timeCount += Time.deltaTime;
		}
		
		if (timeCount >= transitionTime)	// If true, interpolation is done.
		{
			timeCount = 0;
			camera.transform.position = end;
			transitionState++;

			moveCamPos = camera.transform.position;		// Otherwise zooming out from the default zoom in position will jump to a previous moved position.
		}
		else
		{
			fraction = timeCount/transitionTime;
			camera.transform.position = Vector3.Lerp (start, end, waveSmooth (fraction));	// Smooth accelerative interpolation.
		}
	}

	float waveSmooth(float fraction)
	{
		return ((Mathf.Cos ((fraction * Mathf.PI) - Mathf.PI) + 1) / 2);
	}
}
	