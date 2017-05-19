using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour {

	public GameObject player;
	public GameObject terrainObj;

	public float hungerRate = 0.01f;
	public float speedRate = 0.01f;
	public float easyGradientCutoff = 25f;
	public float steepnessPenalty = 0.08f;
	public float staminaLimit = 25000f;

	private Slider staminaSlider;
	private Terrain terrain;

	private Vector3 lastPosition;
	private float dispSpeed;
	private float currentSteepness;

	private float normx;
	private float normz;

	private float staminaCounter;
	private float hungerCounter;
	private float speedCounter;

	// Use this for initialization
	void Start () {
		staminaSlider = GetComponent<Slider> ();
		terrain = terrainObj.GetComponent<Terrain> ();
		lastPosition = player.transform.position;
		staminaCounter = 0f;
		hungerCounter = 0f;
	}

	void FixedUpdate () {
		// calculate current speed of player
		dispSpeed = (((player.transform.position - lastPosition).magnitude) / Time.deltaTime) ;
		lastPosition = player.transform.position;

		// normalize player coordinates to terrain coordinates
		normx = (player.transform.position.x + terrain.terrainData.size.x/2) / terrain.terrainData.size.x;
		normz = (player.transform.position.z + terrain.terrainData.size.z/2) / terrain.terrainData.size.z;

		// get gradient of terrain at normalized coordinates
		currentSteepness = terrain.terrainData.GetSteepness (normx,normz);

		// increment hunger and speed counters
		hungerCounter += hungerRate;
		speedCounter += speedRate * dispSpeed;

		// determine stamina penalty for climbing tall slopes
		if (currentSteepness > easyGradientCutoff) {
			staminaCounter += hungerCounter + speedCounter + steepnessPenalty;
		} else {
			staminaCounter += hungerCounter + speedCounter;
		}
			
		if (staminaCounter >= staminaLimit) {
			// reset counters
			staminaCounter = 0f;
			hungerCounter = 0f;
			speedCounter = 0f;
			// inflict stamina damage
			staminaSlider.value -= 10;
		}

//		Debug.Log ("staminaCounter " + staminaCounter);
	}
}
