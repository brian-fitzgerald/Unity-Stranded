using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldClockScript : MonoBehaviour {

	public GameObject DayTextGameObj;
	public GameObject ActionTextGameObj;
	public GameObject EndGameTextObj;
	public GameObject ScreenImageObj;

	public float totalGameSeconds;

	private int days = 1;
	private float hours = 0f;
	private float minutes = 0f;
//	private float seconds = 0f;

	private string hourStr;
	private string minuteStr;

	private float secondsPerSecond;

	private Text timeText;
	private Text dayText;
	private Text actionText;
	private Text endgameText;
	private Image screenImage;

	// Use this for initialization
	void Start () {
		timeText = GetComponent<Text> ();
		dayText = DayTextGameObj.GetComponent<Text> ();
		actionText = ActionTextGameObj.GetComponent<Text> ();
		endgameText = EndGameTextObj.GetComponent<Text> ();
		screenImage = ScreenImageObj.GetComponent<Image> ();
		secondsPerSecond = 180;
		totalGameSeconds += secondsPerSecond * Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (actionText.text == "Game Over") {
			screenImage.canvasRenderer.SetAlpha (0.5f);
			endgameText.text = "You survived for " + days + " days"+ "\n" +
				"Press 'R' to play again";
			if (Input.GetKeyDown (KeyCode.R)) {
				SceneManager.LoadScene ("Main Scene");
			}

			if (Input.GetKeyDown (KeyCode.Q)) {
				Application.Quit ();
			}
		} else {
			totalGameSeconds += secondsPerSecond * Time.deltaTime;

//			seconds = totalGameSeconds;
			minutes = totalGameSeconds / 60;
			hours = minutes / 60;

			// At midnight, reset hours and increment days
			if (hours >= 24) {
				totalGameSeconds = 0f;
				days++;
				dayText.text = "Day " + days;
			}

			if (hours < 10.0) {
				hourStr = "0" + ((int)hours % 60);
			} else {
				hourStr = ((int)hours % 60).ToString ();
			}

			if (minutes % 60 < 10.0) {
				minuteStr = "0" + ((int)minutes % 60);
			} else {
				minuteStr = ((int)minutes % 60).ToString ();
			}
			
			timeText.text = hourStr + ":" + minuteStr;
		}
	}
}
