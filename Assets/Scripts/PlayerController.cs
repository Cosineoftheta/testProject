using UnityEngine;
using System.Collections;
[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : MonoBehaviour {
	
	public float fSpeed = 1;
	public float fAcc = 5;
	private float fCurrentSpeed_X;
	private float fTargetSpeed_X;
	private float fCurrentSpeed_Y;
	private float fTargetSpeed_Y;
	private float fCurrentSpeed_Z;
	private float fTargetSpeed_Z;
	private Vector3 vMove;
	private bool bPlayerRotateFlag = false;
	private float fMouseX_Start = 0;
	private float fMouseY_Start = 0;
	private PlayerPhysics PlayerPhysics;
	// Use this for initialization
	void Start () {
		PlayerPhysics = GetComponent<PlayerPhysics> ();
	}
	
	// Update is called once per frame
	void Update () {
		fTargetSpeed_X = Input.GetAxisRaw ("Horizontal") * fSpeed;
		fCurrentSpeed_X = IncrementTowards (fCurrentSpeed_X, fTargetSpeed_X, fAcc);
		fTargetSpeed_Y = Input.GetAxisRaw ("Vertical") * fSpeed;
		fCurrentSpeed_Y = IncrementTowards (fCurrentSpeed_Y, fTargetSpeed_Y, fAcc);
		fTargetSpeed_Z = Input.GetAxisRaw ("Jump") * fSpeed;
		//fCurrentSpeed_Z = IncrementTowards (fCurrentSpeed_Z, fTargetSpeed_Z, fAcc);
		vMove = new Vector3 (fCurrentSpeed_X, fCurrentSpeed_Y, -fTargetSpeed_Z);
		PlayerPhysics.Move (vMove);

		if(Input.GetMouseButtonDown(2))
		{
			fMouseX_Start = Input.GetAxis("Mouse X");
			fMouseY_Start = Input.GetAxis("Mouse Y");
			bPlayerRotateFlag = true;
		}

		if(bPlayerRotateFlag)
		{
			float fRotateXDiff = Input.GetAxis("Mouse X") - fMouseX_Start;
			//			Quaternion rotation = Quaternion.Euler (0, fRotateXDiff, 0);
			PlayerPhysics.Rotate (new Vector3(0,0,-fRotateXDiff*2f));
		}

		if(Input.GetMouseButtonUp(2))
		{
			bPlayerRotateFlag = false;
		}
	
	}
	
	private float IncrementTowards(float n, float target, float a){
		if (n == target) {
			return n;
		} 
		else {
			float dir = Mathf.Sign (target - n);
			n += a * Time.deltaTime * dir;
			return (dir == Mathf.Sign (target-n))?n:target;
		}
	}
}
