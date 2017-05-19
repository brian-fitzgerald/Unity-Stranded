using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {

	public GameObject staminaSliderObj;
	public GameObject actionTextObj;

	public int healthPenalty = 10;
	public int healthReward = 10;

	private Slider healthSlider;
	private Slider staminaSlider;
	private Text actionText;

	private float healthPenaltyCounter;
	private float healthRewardCounter;

	// Use this for initialization
	void Start () {
		staminaSlider = staminaSliderObj.GetComponent<Slider> ();
		healthSlider = GetComponent<Slider> ();
		actionText = actionTextObj.GetComponent<Text> ();
		healthPenaltyCounter = 0f;
		healthRewardCounter = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (healthSlider.value > 0) {
			if (staminaSlider.value <= 0) {
				healthPenaltyCounter += Time.deltaTime;
				healthRewardCounter = 0f;
			} else if (staminaSlider.value <= 100) {
				healthRewardCounter += Time.deltaTime;
			}

			if (healthPenaltyCounter >= 18f) {
				healthSlider.value -= healthPenalty;
				healthPenaltyCounter = 0f;
			}

			if (healthRewardCounter >= 24f) {
				healthSlider.value += healthReward;
				healthRewardCounter = 0f;
			}

			// DEMO MODE CHEAT - PRESS 'U' TO GET ZERO HEALTH
			if (Input.GetKeyDown (KeyCode.U)) {
				healthSlider.value = 0;
			}

			if (Input.GetKeyDown (KeyCode.I)) {
				staminaSlider.value = 0;
			}
		} else {
			actionText.text = "Game Over";
		}
	}
}
