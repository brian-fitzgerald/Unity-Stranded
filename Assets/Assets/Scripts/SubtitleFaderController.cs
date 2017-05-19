using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubtitleFaderController : MonoBehaviour {

	private Text subtitle;
	private bool isFadingOut;
	private float timeLeftFadeOut = 2f;
	private float timeLeftFadeIn = 1f;

	// Use this for initialization
	void Start () {
		subtitle = GetComponent<Text> ();
		isFadingOut = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isFadingOut) {
			if (timeLeftFadeOut <= 0f) {
				StartCoroutine (FadeTextToFullAlpha (1f, subtitle));
				isFadingOut = false;
				timeLeftFadeOut = 2f;
			} else {
				timeLeftFadeOut -= Time.deltaTime;
			}
		} else {
			if (timeLeftFadeIn <= 0f) {
				StartCoroutine (FadeTextToZeroAlpha (2f, subtitle));
				isFadingOut = true;
				timeLeftFadeIn = 1f;
			} else {
				timeLeftFadeIn -= Time.deltaTime;
			}
		}
	}

	/*
	 * Obtained below methods from 
	 * https://forum.unity3d.com/threads/fading-in-out-gui-text-with-c-solved.380822/
	 */ 
	public IEnumerator FadeTextToFullAlpha(float t, Text i)
	{
		i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
		while (i.color.a < 1.0f)
		{
			i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
			yield return null;
		}
	}

	public IEnumerator FadeTextToZeroAlpha(float t, Text i)
	{
		i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
		while (i.color.a > 0.0f)
		{
			i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
			yield return null;
		}
	}
}
