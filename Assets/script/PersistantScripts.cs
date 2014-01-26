using UnityEngine;
using System.Collections;

public class PersistantScripts : MonoBehaviour {

	public int choice = 0;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
	}
}
