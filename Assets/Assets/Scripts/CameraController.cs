using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/******************************************************* 
 * Camera that follows player's position and rotation  *
 *******************************************************/
public class CameraController : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;
	private Vector3 desiredPosition;

	public float rotateSpeed = 5f;

	// Use this for initialization
	void Start () {
		offset = player.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;

		float desiredAngle = player.transform.eulerAngles.y;
		Quaternion rotation = Quaternion.Euler (0, desiredAngle, 0);
		transform.position = player.transform.position - (rotation * offset);

		transform.LookAt (player.transform);
		transform.eulerAngles = new Vector3 (20f, transform.eulerAngles.y, transform.eulerAngles.z);
	}
}
