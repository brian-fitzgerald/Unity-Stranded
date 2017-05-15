using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldClockScript : MonoBehaviour {

	public float totalGameSeconds;

	private float days = 1f;
	private float hours = 0f;
	private float minutes = 0f;
	private float seconds = 0f;

	private float secondsPerSecond;

	private GUIText timeText;

	// Use this for initialization
	void Start () {
		GetComponent<GUIText> ();
		secondsPerSecond = 1;
		totalGameSeconds += secondsPerSecond * Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {

		totalGameSeconds += secondsPerSecond * Time.deltaTime;

		seconds = totalGameSeconds;
		minutes = totalGameSeconds / 60;
		hours = minutes / 60;

	}
}
