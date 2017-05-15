using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**********************************************************************************
 * Camera that grants user lots of freedom                                        *
 * obtained from: http://wiki.unity3d.com/index.php?title=MouseOrbitImproved      *
 **********************************************************************************/
public class CameraController2 : MonoBehaviour {

	public GameObject target;
	private float distance;
	public float xSpeed = 120.0f;
	public float ySpeed = 120.0f;

	public float yMinLimit = 10f;
	public float yMaxLimit = 80f;

	public float distanceMin = 5.5f;
	public float distanceMax = 15f;

	private Rigidbody rigidbody;

	float x = 0.0f;
	float y = 0.0f;

	// Use this for initialization
	void Start () {
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;

		distance = transform.position.y - target.transform.position.y;

		rigidbody = GetComponent<Rigidbody>();

		// Make the rigid body not change rotation
		if (rigidbody != null)
		{
			rigidbody.freezeRotation = true;
		}
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (target) 
		{
			x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
			y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

			y = ClampAngle(y, yMinLimit, yMaxLimit);

			Quaternion rotation = Quaternion.Euler(y, x, 0);

			distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel")*5, distanceMin, distanceMax);

			RaycastHit hit;
			if (Physics.Linecast (target.transform.position, transform.position, out hit)) 
			{
				distance -=  hit.distance;
			}
			Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
			Vector3 position = rotation * negDistance + target.transform.position;

			transform.rotation = rotation;
			transform.position = position;
		}
	}

	public static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp(angle, min, max);
	}
}
