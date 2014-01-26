using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
	Vector3 overviewPos = new Vector3(4.606995f, 0, -11.62317f);
	Vector3 closePos = new Vector3(4.606995f, 0, -5);
	float transitionTime = 0.5f;
	float timeCount = 0;
	float fraction = 0;
	const int STATE_UNZOOMED = 0;
	const int STATE_ZOOMING = 1;
	const int STATE_ZOOMED = 2;
	const int STATE_UNZOOMING = 3;
	int transitionState = STATE_UNZOOMED;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (transitionState > 3)
		{
			transitionState = 0;
		}

		if (Input.GetKeyDown(KeyCode.Space) && (transitionState % 2 != 1))	// Not true if zooming/unzooming.
		{
			transitionState++;
		}

		if (transitionState == STATE_ZOOMING)
		{
			interpCamera (overviewPos, closePos);
		}

		if (transitionState == STATE_UNZOOMING)
		{
			interpCamera (closePos, overviewPos);
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
			timeCount = transitionTime;
			transitionState++;
		}
				
		fraction = timeCount/transitionTime;
		camera.transform.position = Vector3.Lerp (start, end, ((Mathf.Cos ((fraction*Mathf.PI)-Mathf.PI)+1)/2));	// Smooth accelerative interpolation.
	}
}
	