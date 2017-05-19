using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaderController : MonoBehaviour {

	private Image blankScreen;

	// Use this for initialization
	void Start () {
		blankScreen = GetComponent<Image> ();
		FadeFromBlack ();
	}

	void FadeFromBlack() {
//		blankScreen.color = Color.black;
		blankScreen.canvasRenderer.SetAlpha (1.0f);
		blankScreen.CrossFadeAlpha (0.0f, 5f, false);
	}
}
