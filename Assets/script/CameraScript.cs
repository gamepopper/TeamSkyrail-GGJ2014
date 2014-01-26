using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	Vector3 overviewPos = new Vector3(4.606995f, 0, -11.62317f);
	Vector3 closePos = new Vector3(4.606995f, 0, -5);
	float transitionTime = 0.5f;
	float timeCount = 0;
	float fraction = 0;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			fraction = timeCount/transitionTime;
			camera.transform.position = Vector3.Lerp (overviewPos, closePos, ((Mathf.Cos ((fraction*Mathf.PI)-Mathf.PI)+1)/2));

			if (timeCount < transitionTime)
			{
				timeCount += Time.deltaTime;
			}
			else
			{
				timeCount = transitionTime;
			}
		}
		else
		{
			camera.transform.position = overviewPos;
			timeCount = 0;
		}
	}
}
