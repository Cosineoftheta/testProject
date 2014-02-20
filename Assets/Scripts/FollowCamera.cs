using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {
	public GameObject target;
	public float damping = 1;
	Vector3 offset;
	private float fX_Angle;
	private float fY_Angle;
	// Use this for initialization
	void Start () {
		offset = target.transform.position - transform.position;
		var angles = transform.eulerAngles;
		fX_Angle = angles.y;
		fY_Angle = angles.x;

	}
	
	// Update is called once per frame
	void LateUpdate () {
//		float currentAngle = transform.eulerAngles.y;
//		float desiredAngle = target.transform.eulerAngles.z;
//		float angle = Mathf.LerpAngle (currentAngle, desiredAngle, Time.deltaTime * damping);
//
//		Quaternion rotation = Quaternion.Euler (0, 0, angle);
//		//transform.position = target.transform.position - (rotation * offset);
//
//
//		float fXdiff = - Mathf.Sin (-target.transform.rotation.z) * offset.y;
//		float fYdiff = - Mathf.Cos (-target.transform.rotation.z) * offset.y;
//		transform.position = target.transform.position - offset + new Vector3 (fXdiff*2, fYdiff*2, 0);
//
//		transform.LookAt (target.transform);
//		transform.Rotate (0, 0, target.transform.rotation.z*20);

		fX_Angle += Input.GetAxis ("Mouse X");
		fY_Angle -= Input.GetAxis ("Mouse Y");
		Quaternion rotation = Quaternion.Euler (fY_Angle, fX_Angle, 0);
		Vector3 postition = rotation * new Vector3 (0.0f, 0.0f, -10f) + target.transform.position;

		transform.rotation = rotation;
		transform.position = postition;



	}
}
