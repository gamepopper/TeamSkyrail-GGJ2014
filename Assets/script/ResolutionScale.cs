using UnityEngine;
using System.Collections;

public class ResolutionScale : MonoBehaviour {

	public float VirtualWidth;
	public float VirtualHeight;
	private Vector3 scale;
	
	// Update is called once per frame
	void Start() {
		scale.x = Screen.width / VirtualWidth;
		scale.y = Screen.height / VirtualHeight;
		scale.z = 1;

		this.transform.localScale = scale;
	}
}
