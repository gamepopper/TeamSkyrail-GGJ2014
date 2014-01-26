using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
	Vector3 overCamPos = new Vector3(4.606995f, 0, -11.62317f);
	Vector3 closeCamPos = new Vector3(4.606995f, 0, -3);
	Vector3 moveCamPos;
	float transitionTime = 0.3f;
	float timeCount = 0;
	float fraction = 0;
	const int STATE_UNZOOMED = 0;
	const int STATE_ZOOMING = 1;
	const int STATE_ZOOMED = 2;
	const int STATE_UNZOOMING = 3;
	int transitionState = STATE_UNZOOMED;

	bool dragging = false;
	float dragSpeed = 0.001f;

	Vector3 dragPos;
	
	// Use this for initialization
	void Start () {
	
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
		}

		if (transitionState == STATE_ZOOMING)
		{
			interpCamera (overCamPos, closeCamPos);
		}

		if (transitionState == STATE_UNZOOMING)
		{
			interpCamera (moveCamPos, overCamPos);
		}

		if (transitionState == STATE_ZOOMED)
		{
			if (Input.GetKeyDown(KeyCode.Mouse1))
			{
				dragPos = Input.mousePosition;
				dragging = true;
			}

			if (Input.GetKeyUp(KeyCode.Mouse1))
			{
				dragging = false;

				moveCamPos = camera.transform.position;
			}

			if (dragging)
			{
				camera.transform.Translate ((Input.mousePosition.x - dragPos.x)*dragSpeed, (Input.mousePosition.y - dragPos.y)*dragSpeed, 0);
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
			camera.transform.position = Vector3.Lerp (start, end, ((Mathf.Cos ((fraction*Mathf.PI)-Mathf.PI)+1)/2));	// Smooth accelerative interpolation.
		}
	}
}
	