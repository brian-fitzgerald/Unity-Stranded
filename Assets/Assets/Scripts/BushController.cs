using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BushController : MonoBehaviour {

	public GameObject actionTextObj;
	public GameObject staminaSliderObj;
	public GameObject healthSliderObj;

	public float playerHitRadius = 3f;

	private Text actionText;
	private Slider staminaSlider;
	private Slider healthSlider;

	private string berryString;
	private int staminaEffect = 0;
	private int healthEffect = 0;
	private float timeUntilRespawn = 0f;
	private bool decrementRespawn = true;

	// Use this for initialization
	void Start () {
		actionText = actionTextObj.GetComponent<Text> ();
		staminaSlider = staminaSliderObj.GetComponent<Slider> ();
		healthSlider = healthSliderObj.GetComponent<Slider> ();
		assignBerry ();
	}
	
	void FixedUpdate () {
		Collider[] colliders = Physics.OverlapSphere (transform.position, playerHitRadius);
		decrementRespawn = true;

		for (int i = 0; i < colliders.Length; i++) {
			if (colliders [i].CompareTag ("Player")) {
				if (timeUntilRespawn <= 0f) {
					decrementRespawn = false;
					actionText.text = "Left click to pick a " + berryString;

					if (Input.GetMouseButtonDown (0)) {
						timeUntilRespawn = 300f;
						staminaSlider.value += staminaEffect;
						healthSlider.value += healthEffect;
					}
				} else {
					actionText.text = "No berries to be found here";
				}
			}
		}

		if (decrementRespawn)
			timeUntilRespawn -= Time.deltaTime;
	}

	private void assignBerry() {
		float randomNum;
		// assign value based on elevation
		if (transform.position.y >= 60f) {
			randomNum = Random.Range (0.98f, 1f);
		} else if (transform.position.y >= 40f) {
			randomNum = Random.Range (0.2f, 0.9f);
		} else if (transform.position.x >= 100f || transform.position.z >= 100f) {
			randomNum = Random.Range (0.5f, 0.88f);
		} else if (transform.position.x <= -100f || transform.position.z <= -100f) {
			randomNum = Random.Range (0.65f, 0.75f);
		} else {
			randomNum = Random.Range (0f, 1f);
		}

		if (randomNum < 0.4f) {
			staminaEffect = 10;
			healthEffect = 0;
			berryString = "BLUEBERRY";
		} else if (randomNum < 0.6f) {
			staminaEffect = 20;
			healthEffect = 0;
			berryString = "BLACKBERRY";
		} else if (randomNum < 0.65f) {
			staminaEffect = 30;
			healthEffect = 0;
			berryString = "GOOSEBERRY";
		} else if (randomNum < 0.75f) {
			staminaEffect = Random.Range (-20, 40);
			healthEffect = Random.Range (-10, 20);
			berryString = "MYSTERYBERRY";
		} else if (randomNum < 0.94f) {
			staminaEffect = -20;
			healthEffect = -10;
			berryString = "DANGERBERRY";
		} else if (randomNum < 0.99f) {
			staminaEffect = -100;
			healthEffect = -100;
			berryString = "DEATHBERRY";
		} else {
			staminaEffect = 100;
			healthEffect = 100;
			berryString = "GODBERRY";
		}
	}
}
