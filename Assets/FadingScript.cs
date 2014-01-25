using UnityEngine;
using System.Collections;

public class FadingScript : MonoBehaviour {

	public bool StartFade = false;
	public bool FadeIn = false;
	public bool FadeOut = false;
	public float Delay = 0f;
	public float FadeSpeed = 1f;

	private float elapsed = 0f;
	private bool fadeInComplete = false;
	private bool fadeOutComplete = false;

	private Color colorData;

	// Use this for initialization
	void Start() 
	{
		colorData = gameObject.renderer.material.color;

		if (FadeIn) 
		{
			colorData.a = 0;
			setColor (colorData);
		} 
		else 
		{
			fadeInComplete = true;
		}
	}

	private void setColor(Color c)
	{
		gameObject.renderer.material.color = colorData;
	}

	public bool IsFadeInStart()
	{
		return (FadeIn && !fadeInComplete);
	}

	public bool IsFadeOutStart()
	{
		return (FadeOut && 
		        !fadeOutComplete && 
		        fadeInComplete && 
		        elapsed > Delay);
	}

	public bool IsFadeInComplete()
	{
		return fadeInComplete;
	}

	public bool IsFadeOutComplete()
	{
		return fadeOutComplete;
	}

	// Update is called once per frame
	void Update() {
		if (StartFade) {
			if (FadeIn) {
				if (fadeInComplete == false) {
						colorData.a += (Time.deltaTime / FadeSpeed);
				
						if (colorData.a > 1) {
							colorData.a = 1;
							fadeInComplete = true;
						}
				}
			}
		
			if (fadeInComplete) {
				elapsed += Time.deltaTime;
		
				if (elapsed > Delay) {
					if (FadeOut) {
						if (fadeOutComplete == false) {
							colorData.a -= (Time.deltaTime / FadeSpeed);
				
							if (colorData.a < 0) {
								colorData.a = 0;
								fadeOutComplete = true;
								StartFade = false;
							}
						}
					}
				}
			}
		}

		setColor(colorData);
	}
}
