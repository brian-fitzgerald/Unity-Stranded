using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 
 * This class is strictly to determine if actionText should
 * be an empty string based on if a bush is not nearby
 */
public class WorldActionListener : MonoBehaviour {

	public GameObject actionTextObj;
	public float bushHitRadius = 3f;

	private Text actionText;
	private bool bushNearby;

	// Use this for initialization
	void Start () {
		bushNearby = false;
		actionText = actionTextObj.GetComponent<Text> ();
	}
	
	void FixedUpdate () {
		bushNearby = false;
		Collider[] colliders = Physics.OverlapSphere (transform.position, bushHitRadius);

		for (int i = 0; i < colliders.Length; i++) {
			if (colliders [i].CompareTag ("Bush")) {
				bushNearby = true;
			}
		}

		if (!bushNearby) {
			actionText.text = "";
		}
	}
}
