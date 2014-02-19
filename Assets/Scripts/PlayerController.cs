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
		fCurrentSpeed_Z = IncrementTowards (fCurrentSpeed_Z, fTargetSpeed_Z, fAcc);
		vMove = new Vector3 (fCurrentSpeed_X, fCurrentSpeed_Y, -fCurrentSpeed_Z);
		PlayerPhysics.Move (vMove);
	
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
